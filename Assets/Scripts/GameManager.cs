using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void QuitGame() {

        // to do: make sure to save which pages the player has seen

#if UNITY_EDITOR
        Debug.Log("Game quit!");
#endif

        Application.Quit();
    }
}