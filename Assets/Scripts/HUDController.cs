using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour {
    public TextMeshProUGUI PageText;
    public TextMeshProUGUI PageNumber;

    [Space]
    public Button NextButton;
    public Button BackButton;
    public Button EndButton;

    [Space]
    public Image CurrentBorder;
    public Sprite FallBorder;
    public Sprite PreWinterBorder;
    public Sprite WinterBorder;
    public Sprite PreSpringBorder;
    public Sprite SpringBorder;

    [Space]
    public InGameManager InGameManager;

    private void Awake() {
        InGameManager.PageChanged += InGameManager_PageChanged;
    }

    private void OnDisable() {
        InGameManager.PageChanged -= InGameManager_PageChanged;
    }

    private void InGameManager_PageChanged(PageSO page, bool isLastPage) {
        PageText.text = page.PageText;
        PageNumber.text = page.PageNumber.ToString();

        NextButton.gameObject.SetActive(!isLastPage);
        EndButton.gameObject.SetActive(isLastPage);

        switch (page.Season) {

            case Season.Fall:
                CurrentBorder.sprite = FallBorder;
                break;
            case Season.PreWinter:
                CurrentBorder.sprite = PreWinterBorder;
                break;
            case Season.Winter:
                CurrentBorder.sprite = WinterBorder;
                break;
            case Season.PreSpring:
                CurrentBorder.sprite = PreSpringBorder;
                break;
            case Season.Spring:
                CurrentBorder.sprite = SpringBorder;
                break;
            default:
                Debug.LogError("Season " + page.Season + " should not exist.");
                break;
        }
    }
}