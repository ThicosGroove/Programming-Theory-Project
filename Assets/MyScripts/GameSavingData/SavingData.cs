using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavingData : MonoBehaviour
{
    public static SavingData Instance { get; private set; }

    public string _name;
    public GameObject _vehicle;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        LoadNewData();
    }

    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int HighScore;
        public string BestPlayer;
        public GameObject Vehicle;
    }


    public void SaveNewData()
    {
        SaveData data = new SaveData();

        data.Name = _name;
        data.Vehicle = _vehicle;

        string json = JsonUtility.ToJson(data);

        File.AppendAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNewData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _name = data.Name;
            _vehicle = data.Vehicle;
        }
    }

}
