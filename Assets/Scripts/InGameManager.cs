using UnityEngine;
using System.Collections.Generic;

public class InGameManager : MonoBehaviour {

    public List<PageSO> Pages = new List<PageSO>();

    private int PageIndex = 0;
    private int TextIndex = 0;

    public event System.Action<PageSO, int, int, bool, bool> PageChanged;
    public event System.Action<string, bool, bool> TextChanged;

    private void OnEnable() {
        SetPage(Pages.FindIndex(p => p.Season == GameManager.SeasonToPlay), 0);
    }

    public void SetPage(int pageIndex, int textIndex) {

        // check if a new season has started
        if ((int)Pages[PageIndex].Season < (int)Pages[pageIndex].Season) {
            GameManager.LastSeasonStarted = (int)Pages[pageIndex].Season;
        }

        TextIndex = textIndex;
        PageIndex = pageIndex;

        bool isFirstText = PageIndex == 0 && TextIndex == 0;
        bool isLastText = PageIndex == Pages.Count - 1 && TextIndex == Pages[Pages.Count - 1].TextSections.Count - 1;

        PageChanged?.Invoke(Pages[PageIndex], pageIndex, textIndex, isFirstText, isLastText);
    }

    public void SetText(int textIndex) {
        TextIndex = textIndex;

        bool isFirstText = PageIndex == 0 && TextIndex == 0;
        bool isLastText = PageIndex == Pages.Count - 1 && TextIndex == Pages[Pages.Count - 1].TextSections.Count - 1;

        TextChanged?.Invoke(Pages[PageIndex].TextSections[TextIndex], isFirstText, isLastText);
    }

    public void AdvanceText() {

        // advance text
        if (TextIndex < Pages[PageIndex].TextSections.Count - 1) {
            SetText(TextIndex + 1);
        }

        // if end of page reached, advance to next page
        else if (PageIndex < Pages.Count - 1) {
            SetPage(PageIndex + 1, 0);
        }
    }

    public void ReduceText() {

        // reduce text
        if (TextIndex > 0) {
            SetText(TextIndex - 1);
        }

        // if start of page reached, go back to previous page
        else if (PageIndex > 0) {
            SetPage(PageIndex - 1, Pages[PageIndex - 1].TextSections.Count - 1);
        }
    }

    public void EndGame() {
        FindObjectOfType<GameManager>().EndGame();
    }
}