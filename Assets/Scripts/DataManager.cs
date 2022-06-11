using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public static int highScore;

    public string playerName = "Chris";
    
    
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

    // Method called when m_Gameover = true to collect score, and update session and JSON file with high score
    public void ReportScore(int score)
    {
        int currentScore;
        currentScore = score;
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
        Debug.Log("The score is " + currentScore);
        Debug.Log("The high score is " + highScore);
    }

    public int SetHighScore()
    {
        return highScore;
    }

    public string GetName()
    {
        return playerName;
    }
}
