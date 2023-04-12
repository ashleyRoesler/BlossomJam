using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public void EndGame() {
        FindObjectOfType<GameManager>().EndGame();
    }
}