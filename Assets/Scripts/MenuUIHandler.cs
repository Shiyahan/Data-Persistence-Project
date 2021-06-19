using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerName;


    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManage.Instance.returnToMainMenu)
        {
            SaveBest(ScoreManage.Instance.bestPlayerName, ScoreManage.Instance.bestScore);
        }
        LoadBest();
            
    }

    // Update is called once per frame
    void Update()
    {
        ScoreManage.Instance.currentPlayerName = playerName.text;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveBest(string bestPlayerName, int bestScore)
    {
        Debug.Log(Application.persistentDataPath);
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            ScoreManage.Instance.bestPlayerName = data.bestPlayerName;
            ScoreManage.Instance.bestScore = data.bestScore;
            bestScoreText.text = "Best Score: " + ScoreManage.Instance.bestPlayerName + " " + ScoreManage.Instance.bestScore;
        }
    }

}
