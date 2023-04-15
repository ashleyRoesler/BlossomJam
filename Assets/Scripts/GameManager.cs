using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string MainMenuSceneName;
    public string GameSceneName;
    public string EndSceneName;

    [Space]
    public GameObject LoadingScreenCanvas;
    public Image LoadingScreen;

    [Space]
    public float LoadTime = 1f;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame(int pageIndex = 0) {

        // to do: make player able to load to specific scene... how??? Page manager? page event?

        // to do: show instructions on how to play

        StartCoroutine(LoadScene_Coroutine(GameSceneName));
    }

    public void GoToMainMenu() {
        StartCoroutine(LoadScene_Coroutine(MainMenuSceneName));
    }

    public void EndGame() {
        StartCoroutine(LoadScene_Coroutine(EndSceneName));
    }

    private IEnumerator LoadScene_Coroutine(string scene) {

        LoadingScreenCanvas.SetActive(true);

        Color c = LoadingScreen.color;

        // fade in loading screen
        for (float alpha = 0f; alpha <= 1f; alpha += 0.2f) {
            c.a = alpha;
            LoadingScreen.color = c;
            yield return new WaitForSeconds(0.02f);
        }

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

    public void QuitGame() {

        // to do: make sure to save which pages the player has seen

#if UNITY_EDITOR
        Debug.Log("Game quit!");
#endif

        Application.Quit();
    }
}