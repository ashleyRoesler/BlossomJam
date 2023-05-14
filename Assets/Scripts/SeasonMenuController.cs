using UnityEngine;
using UnityEngine.UI;

public class SeasonMenuController : MonoBehaviour {

    public Button FallButton;
    public Button PreWinterButton;
    public Button WinterButton;
    public Button PreSpringButton;
    public Button SpringButton;

    private void Awake() {
        FallButton.interactable = GameManager.LastSeasonStarted >= 0;
        PreWinterButton.interactable = GameManager.LastSeasonStarted >= 1;
        WinterButton.interactable = GameManager.LastSeasonStarted >= 2;
        PreSpringButton.interactable = GameManager.LastSeasonStarted >= 3;
        SpringButton.interactable = GameManager.LastSeasonStarted == 4;
    }
}