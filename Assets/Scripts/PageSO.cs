using UnityEngine;

[CreateAssetMenu(fileName = "Page", menuName = "ScriptableObjects/Page", order = 1)]
public class PageSO : ScriptableObject {

    public int PageNumber;
    public Season Season;

    [Space, TextArea]
    public string PageText;
}

public enum Season {
    Fall,
    PreWinter,
    Winter,
    PreSpring,
    Spring
}