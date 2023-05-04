using UnityEngine;
using System.Collections.Generic;

public class InGameManager : MonoBehaviour {

    public List<PageSO> Pages = new List<PageSO>();

    private int CurrentPage = 0;

    public event System.Action<PageSO, bool> PageChanged;

    private void OnEnable() {

        // todo: allow main menu to choose starting page

        SetPage(0);
    }

    public void SetPage(int page) {
        CurrentPage = page;
        PageChanged?.Invoke(Pages[CurrentPage], CurrentPage == Pages.Count - 1);
    }

    public void AdvancePage() {
        if (CurrentPage < Pages.Count - 1) {
            SetPage(CurrentPage + 1);
        }
    }

    public void ReducePage() {
        if (CurrentPage > 0) {
            SetPage(CurrentPage - 1);
        }
    }

    public void EndGame() {
        FindObjectOfType<GameManager>().EndGame();
    }
}