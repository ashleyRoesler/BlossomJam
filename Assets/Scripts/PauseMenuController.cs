using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    public KeyCode PauseKey = KeyCode.P;

    public GameObject PauseScreen;

    public void Update() {
        if (Input.GetKeyDown(PauseKey))
            PauseScreen.SetActive(!PauseScreen.activeInHierarchy);
    }

    public void GoToMainMenu() {
        GameManager.Instance.GoToMainMenu();
    }
}