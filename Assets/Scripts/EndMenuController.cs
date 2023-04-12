using UnityEngine;

public class EndMenuController : MonoBehaviour
{
    public void GoToMainMenu() {
        FindObjectOfType<GameManager>().GoToMainMenu();
    }

    public void QuitGame() {
        FindObjectOfType<GameManager>().QuitGame();
    }
}