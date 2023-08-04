using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Button PlayButton;
    public Button QuitButton;

    private void Start() {

        PlayButton.onClick.AddListener(() => {
            GameManager.Instance.PlayGame(0);
        });

        QuitButton.onClick.AddListener(() => {
            GameManager.Instance.QuitGame();
        });
    }
}