using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManage : MonoBehaviour
{
    public static ScoreManage Instance;
    public string bestPlayerName;
    public string currentPlayerName;
    public int bestScore;
    public int currentScore;
    public bool returnToMainMenu;

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
}
