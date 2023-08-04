using UnityEngine;

public class EndMenuController : MonoBehaviour {
    public void GoToMainMenu() {
        GameManager.Instance.GoToMainMenu();
    }

    public void QuitGame() {
        GameManager.Instance.QuitGame();
    }
}