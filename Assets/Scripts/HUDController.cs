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
    }
}