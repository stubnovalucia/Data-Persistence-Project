using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    public string playerName = ""; 
    public BestScore bestScore;
    public InputField player;

    public Text BestScoreText; 
     private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
        BestScoreText.text = "Best Score: " + bestScore.playerName + ": " + bestScore.score;

    }

    [System.Serializable]
    public class BestScore
    {
        public string playerName;
        public int score;
        public string lastPlayer;
    }

    public void SaveBestScore()
    {

        string json = JsonUtility.ToJson(bestScore);
    
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        bestScore.playerName = "";
        bestScore.score = 0;
        bestScore.lastPlayer = "";

        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestScore = JsonUtility.FromJson<BestScore>(json);
            player.text = bestScore.lastPlayer;
        } 
    }

    public void ChangePlayerName() {
        playerName = player.text;
        bestScore.lastPlayer = player.text;
        SaveBestScore();
    }

}
