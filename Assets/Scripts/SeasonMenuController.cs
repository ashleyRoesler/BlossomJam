using UnityEngine;
using UnityEngine.UI;

public class SeasonMenuController : MonoBehaviour {

    public Button FallButton;
    public Button PreWinterButton;
    public Button WinterButton;
    public Button PreSpringButton;
    public Button SpringButton;

    private void Awake() {
        FallButton.interactable = GameManager.Instance.LastSeasonStarted >= 0;
        PreWinterButton.interactable = GameManager.Instance.LastSeasonStarted >= 1;
        WinterButton.interactable = GameManager.Instance.LastSeasonStarted >= 2;
        PreSpringButton.interactable = GameManager.Instance.LastSeasonStarted >= 3;
        SpringButton.interactable = GameManager.Instance.LastSeasonStarted == 4;
    }
}