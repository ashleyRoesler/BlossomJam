using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Page", menuName = "ScriptableObjects/Page", order = 1)]
public class PageSO : ScriptableObject {

    public Season Season;

    [Space, TextArea(10, 20)]
    public List<string> TextSections = new List<string>();

    [Space]
    public GameObject EnvironmentPrefab;
}

public enum Season {
    Fall = 0,
    PreWinter = 1,
    Winter = 2,
    PreSpring = 3,
    Spring = 4
}