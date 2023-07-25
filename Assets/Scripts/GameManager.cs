using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public string MainMenuSceneName;
    public string GameSceneName;
    public string EndSceneName;

    [Space]
    public GameObject LoadingScreenCanvas;
    public Image LoadingScreen;
    public GameObject HowToPlay;
    public Button ContinueButton;

    [Space]
    public float LoadTime = 1f;

    static public Season SeasonToPlay = Season.Fall;
    static public int LastSeasonStarted = 0;
    static public int LastPageUnlocked = -1;

    public void Awake() {
        DontDestroyOnLoad(gameObject);

        ContinueButton.onClick.AddListener(() => {
            HowToPlay.SetActive(false);
            StartCoroutine(LoadOut_Coroutine(GameSceneName));
        });
    }

    public void PlayGame(int season) {

        SeasonToPlay = (Season)season;

        StartCoroutine(LoadIn_Coroutine(true));
    }

    public void GoToMainMenu() {
        StartCoroutine(LoadScene_Coroutine(MainMenuSceneName));
    }

    public void EndGame() {
        StartCoroutine(LoadScene_Coroutine(EndSceneName));
    }

    private IEnumerator LoadIn_Coroutine(bool showHowToPlay = false) {

        LoadingScreenCanvas.SetActive(true);

        Color c = LoadingScreen.color;

        // fade in loading screen
        for (float alpha = 0f; alpha <= 1f; alpha += 0.2f) {
            c.a = alpha;
            LoadingScreen.color = c;
            yield return new WaitForSeconds(0.02f);
        }

        // show how to play instructions
        HowToPlay.SetActive(showHowToPlay);
    }

    private IEnumerator LoadOut_Coroutine(string scene) {

        Color c = LoadingScreen.color;

        // load scene
        SceneManager.LoadScene(scene);

        yield return new WaitForSeconds(LoadTime);

        // fade out loading screen
        for (float alpha = 1f; alpha >= 0f; alpha -= 0.2f) {
            c.a = alpha;
            LoadingScreen.color = c;
            yield return new WaitForSeconds(0.02f);
        }

        LoadingScreenCanvas.SetActive(false);
    }

    private IEnumerator LoadScene_Coroutine(string scene) {
        yield return LoadIn_Coroutine();
        yield return LoadOut_Coroutine(scene);
    }

    public void QuitGame() {

        // to do: make sure to save which pages the player has seen

#if UNITY_EDITOR
        Debug.Log("Game quit!");
#endif

        Application.Quit();
    }
}