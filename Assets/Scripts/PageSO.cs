using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Page", menuName = "ScriptableObjects/Page", order = 1)]
public class PageSO : ScriptableObject {

    public int PageNumber;
    public Season Season;

    [Space, TextArea(10,20)]
    public string PageText;

    [Space, TextArea(10, 20)]
    public List<string> PageTexts = new List<string>();
}

public enum Season {
    Fall,
    PreWinter,
    Winter,
    PreSpring,
    Spring
}