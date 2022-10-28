using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;

    public string currentPlayerName;

    public string Highscore_playerName;
    public int Highscore_score;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }




    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }


    public void SaveHighScore(int score)
    {
        SaveData data = new SaveData();
        data.name = currentPlayerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Highscore_playerName = data.name;
            Highscore_score = data.score;
        }
    }



}
