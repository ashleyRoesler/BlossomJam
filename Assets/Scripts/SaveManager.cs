using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour {

    private const string _saveFilePath = "/save.dat";

    public static SaveManager Instance;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        if (!Instance) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Load();
    }

    public void Save() {

        string destination = Application.persistentDataPath + _saveFilePath;
        FileStream file;

        // look for save file
        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
        }

        // create file if none found
        else {
            file = File.Create(destination);
        }

        // create new save
        SaveData data = new(GameManager.Instance.LastPageUnlocked, GameManager.Instance.LastSeasonStarted);

        // save to file and close file
        BinaryFormatter bf = new();
        bf.Serialize(file, data);
        file.Close();
    }

    private void Load() {

        string destination = Application.persistentDataPath + _saveFilePath;
        FileStream file;

        // look for save file
        if (File.Exists(destination)) {
            file = File.OpenRead(destination);

            BinaryFormatter bf = new();
            SaveData data = (SaveData) bf.Deserialize(file);
            file.Close();

            GameManager.Instance.LastPageUnlocked = data.LastPageUnlockedIndex;
            GameManager.Instance.LastSeasonStarted = data.LastSeasonStarted;
        }

        // if no save file found, load default values
        else {
            GameManager.Instance.LastPageUnlocked = -1;
            GameManager.Instance.LastSeasonStarted = 0;
        }
    }
}