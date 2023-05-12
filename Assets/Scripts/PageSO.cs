using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Page", menuName = "ScriptableObjects/Page", order = 1)]
public class PageSO : ScriptableObject {

    public Season Season;

    [Space, TextArea(10, 20)]
    public List<string> TextSections = new List<string>();
}

public enum Season {
    Fall,
    PreWinter,
    Winter,
    PreSpring,
    Spring
}