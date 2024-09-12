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

    void Start(){
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

    /*
    Zu müde grad. puh.
    Habe die class und die methods eingebaut um Score und Namen zu speichern.
    Die werden aber noch nirgends aufgerufen.
    Auch fehlt noch die Logik, die den best score mit dem current score abgleicht.
    Ich hatte mir das so gedacht, dass sobald der current score höher ist als der highscore,
    soll auch beim laufenden spiel das aktualisiert werden.
    Und dann geschrieben selbstverständlich.
    */

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
    }
}
