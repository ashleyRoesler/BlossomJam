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
        InGameManager.TextChanged += InGameManager_TextChanged;
    }

    private void OnDisable() {
        InGameManager.PageChanged -= InGameManager_PageChanged;
        InGameManager.TextChanged -= InGameManager_TextChanged;
    }

    private void InGameManager_TextChanged(string text) {
        PageText.text = text;
    }

    private void InGameManager_PageChanged(PageSO page, bool isFirstPage, bool isLastPage, int textIndex) {

        Debug.LogWarning("TEXT INDEX: " + textIndex);

        PageText.text = page.TextSections[textIndex];
        PageNumber.text = page.PageNumber.ToString();

        BackButton.gameObject.SetActive(!isFirstPage);
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