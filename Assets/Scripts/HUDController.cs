using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour {
    public TextMeshProUGUI PageText;
    public TextMeshProUGUI PageNumber;

    private int _pageNumber;

    [Space]
    public Button NextButton;
    public TextMeshProUGUI NextButtonText;

    public Button BackButton;
    public TextMeshProUGUI BackButtonText;

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

    private void SetNavButtons(PageSO page, int textIndex, bool isFirstText, bool isLastText) {

        // set navigation button text
        NextButtonText.text = textIndex < page.TextSections.Count - 1 ? "-->" : "Page " + (_pageNumber + 1);
        BackButtonText.text = textIndex > 0 ? "<--" : "Page " + (_pageNumber - 1);

        // show/hide navigation buttons
        BackButton.gameObject.SetActive(!isFirstText);
        NextButton.gameObject.SetActive(!isLastText);
        EndButton.gameObject.SetActive(isLastText);
    }

    private void InGameManager_TextChanged(PageSO page, int textIndex, bool isFirstText, bool isLastText) {
        PageText.text = page.TextSections[textIndex];

        // configure navigation buttons
        SetNavButtons(page, textIndex, isFirstText, isLastText);
    }

    private void InGameManager_PageChanged(PageSO page, int pageIndex, int textIndex, bool isFirstText, bool isLastText) {

        // set text
        PageText.text = page.TextSections[textIndex];
        PageText.color = page.TextColor;

        // set page number
        _pageNumber = pageIndex + 1;
        PageNumber.text = (pageIndex + 1).ToString();

        // configure navigation buttons
        SetNavButtons(page, textIndex, isFirstText, isLastText);

        // set season border
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