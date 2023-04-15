using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string MainMenuSceneName;
    public string GameSceneName;
    public string EndSceneName;

    public GameObject LoadingScreenCanvas;
    public Image LoadingScreen;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame(int pageIndex = 0) {

        // to do: make player able to load to specific scene... how??? Page manager? page event?

        // to do: show instructions on how to play

        StartCoroutine(LoadingScreen_Coroutine());
        SceneManager.LoadScene(GameSceneName);
    }

    public void GoToMainMenu() {
        StartCoroutine(LoadingScreen_Coroutine());
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void EndGame() {
        StartCoroutine(LoadingScreen_Coroutine());
        SceneManager.LoadScene(EndSceneName);
    }

    private IEnumerator LoadingScreen_Coroutine() {

        LoadingScreenCanvas.SetActive(true);

        yield return new WaitForSeconds(0.5f);

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