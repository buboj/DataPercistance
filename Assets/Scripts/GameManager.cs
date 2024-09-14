using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string bestPlayerName = "Kalle";
    public int bestScore = 0;

    int oldBestScore;
    public int currentScore = 0;

    private void Start() {
        
    }

    void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    [System.Serializable]
    class SaveData{
        public string nameToSave;
        public int scoreToSave;
    }

    public void SaveNameScore(){
        if (bestScore > oldBestScore){
            Debug.Log("Try to Save Game");
            SaveData data = new SaveData();
            data.nameToSave = bestPlayerName;
            data.scoreToSave = bestScore;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/saveNameScore.json", json);
        }
                    
    }

    public void LoadNameScore(){
        Debug.Log("Try to Load Game");
        string path = Application.persistentDataPath + "/saveNameScore.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data.scoreToSave > bestScore){
                bestPlayerName = data.nameToSave;
                bestScore = oldBestScore = data.scoreToSave;
            }
            
        }
        else{
            Debug.Log("No Json File");
        }
    }
}
