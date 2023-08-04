
// https://discussions.unity.com/t/how-do-you-save-write-and-load-from-a-file/180577

[System.Serializable]
public class SaveData {

    public int LastPageUnlockedIndex;
    public int LastSeasonStarted;

    public SaveData(int page, int season) {
        LastPageUnlockedIndex = page;
        LastSeasonStarted = season;
    }
}