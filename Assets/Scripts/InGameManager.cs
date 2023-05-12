using UnityEngine;
using System.Collections.Generic;

public class InGameManager : MonoBehaviour {

    public List<PageSO> Pages = new List<PageSO>();

    private int PageIndex = 0;
    private int TextIndex = 0;

    public event System.Action<PageSO, bool, bool> PageChanged;
    public event System.Action<string> TextChanged;

    private void OnEnable() {

        // todo: allow main menu to choose starting page

        SetPage(0);
    }

    public void SetPage(int pageIndex) {
        TextIndex = 0;
        PageIndex = pageIndex;
        PageChanged?.Invoke(Pages[PageIndex], PageIndex == 0, PageIndex == Pages.Count - 1);
    }

    public void SetText(int textIndex) {
        TextIndex = textIndex;
        TextChanged?.Invoke(Pages[PageIndex].PageTexts[TextIndex]);
    }

    public void AdvanceText() {

        // advance text
        if (TextIndex < Pages[PageIndex].PageTexts.Count - 1) {
            SetText(TextIndex + 1);
        }

        // if end of page reached, advance to next page
        else if (PageIndex < Pages.Count - 1) {
            SetPage(PageIndex + 1);
        }
    }

    public void ReduceText() {

        // reduce text
        if (TextIndex > 0) {
            SetText(TextIndex - 1);
        }

        // if start of page reached, go back to previous page
        else if (PageIndex > 0) {
            SetPage(PageIndex - 1);
        }
    }

    public void EndGame() {
        FindObjectOfType<GameManager>().EndGame();
    }
}