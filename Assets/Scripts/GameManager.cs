using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore;
    public int currentScore = 0;

    void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameScore();
    }

    [System.Serializable]
    class SaveData{
        public string nameToSave;
        public int scoreToSave;
    }

    public void SaveNameScore(){
        SaveData data = new SaveData();
        data.nameToSave = bestPlayerName;
        data.scoreToSave = bestScore;
        string json = JsonUtility.ToJson(data);
        // File.WriteAllText(Application.persistentDataPath + "/saveNameScore.json", json);
        File.WriteAllText("C:/Users/jo/Dectop/saveNameScore.json", json);
    }

    public void LoadNameScore(){
        // string path = Application.persistentDataPath + "/saveNameScore.json";
        string path = "C:/Users/jo/Dectop/saveNameScore.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.nameToSave;
            bestScore = data.scoreToSave;
        }
        else{
            bestScore = 0;
            bestPlayerName = "No One Yet!";
        }
    }
}
