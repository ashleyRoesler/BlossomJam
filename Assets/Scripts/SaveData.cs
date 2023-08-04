
[System.Serializable]
public class SaveData {

    public int LastPageUnlockedIndex;
    public int LastSeasonStarted;

    public SaveData(int page, int season) {
        LastPageUnlockedIndex = page;
        LastSeasonStarted = season;
    }
}