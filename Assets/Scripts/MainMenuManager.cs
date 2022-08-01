using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    public static string playerName; 
     private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadName(); 
    }

//     [System.Serializable]
//     class SaveData
//     {
//         public Color TeamColor;
//     }

//     public void SaveColor()
// {
//         SaveData data = new SaveData();
//         data.TeamColor = TeamColor;

//         string json = JsonUtility.ToJson(data);
    
//         File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
//     }

//     public void LoadColor()
//     {
//         string path = Application.persistentDataPath + "/savefile.json";
//         if (File.Exists(path))
//         {
//             string json = File.ReadAllText(path);
//             SaveData data = JsonUtility.FromJson<SaveData>(json);

//             TeamColor = data.TeamColor;
//         }
//     }

}
