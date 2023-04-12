using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainMenuSceneName;
    public string GameSceneName;
    public string EndSceneName;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame(int pageIndex = 0) {

        // to do: make player able to load to specific scene... how??? Page manager? page event?

        SceneManager.LoadScene(GameSceneName);
    }

    public void QuitGame() {

        // to do: make sure to save which pages the player has seen

#if UNITY_EDITOR
        Debug.Log("Game quit!");
#endif

        Application.Quit();
    }
}