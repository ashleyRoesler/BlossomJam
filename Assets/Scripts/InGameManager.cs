using UnityEngine;
using System.Collections.Generic;

public class InGameManager : MonoBehaviour {

    public List<PageSO> Pages = new List<PageSO>();

    private int PageIndex = 0;
    private int TextIndex = 0;

    public event System.Action<PageSO, int, int, bool, bool> PageChanged;
    public event System.Action<PageSO, int, bool, bool> TextChanged;

    private GameObject _spawnedEnvironment = null;

    private void OnEnable() {
        SetPage(Pages.FindIndex(p => p.Season == GameManager.Instance.SeasonToPlay), 0);
    }

    public void SetPage(int pageIndex, int textIndex) {

        bool needToSave = false;

        // set the previous page as unlocked
        if (pageIndex - 1 > GameManager.Instance.LastPageUnlocked) {
            GameManager.Instance.LastPageUnlocked = pageIndex - 1;

            needToSave = true;
        }

        // check if a new season has started
        if ((int)Pages[PageIndex].Season < (int)Pages[pageIndex].Season) {
            GameManager.Instance.LastSeasonStarted = (int)Pages[pageIndex].Season;

            needToSave = true;
        }

        // change text
        TextIndex = textIndex;
        PageIndex = pageIndex;

        bool isFirstText = PageIndex == 0 && TextIndex == 0;
        bool isLastText = PageIndex == Pages.Count - 1 && TextIndex == Pages[Pages.Count - 1].TextSections.Count - 1;

        // change environment (delete old, instantiate new)
        if (_spawnedEnvironment) {
            Destroy(_spawnedEnvironment);
        }

        _spawnedEnvironment = Instantiate(Pages[PageIndex].EnvironmentPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        PageChanged?.Invoke(Pages[PageIndex], pageIndex, textIndex, isFirstText, isLastText);

        if (needToSave) {
            SaveManager.Instance.Save();
        }
    }

    public void SetText(int textIndex) {
        TextIndex = textIndex;

        bool isFirstText = PageIndex == 0 && TextIndex == 0;
        bool isLastText = PageIndex == Pages.Count - 1 && TextIndex == Pages[Pages.Count - 1].TextSections.Count - 1;

        TextChanged?.Invoke(Pages[PageIndex], TextIndex, isFirstText, isLastText);
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

    public void SkipToNextPage() {
        SetPage(PageIndex + 1, 0);
    }

    public void EndGame() {
        GameManager.Instance.EndGame();
    }
}