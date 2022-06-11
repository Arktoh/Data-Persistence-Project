using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    //public static int highScore;

    public string playerName;

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
    public void SetScore(string name, int score)
    {
        int currentScore;
        string currentName;
        currentScore = score;
        currentName = name;
        if (currentScore > TopPlayer.highScore)
        {
            TopPlayer.highScore = currentScore;
            TopPlayer.highName = currentName;
        }
        Debug.Log("The score is " + currentScore);
        Debug.Log("The high score is " + TopPlayer.highScore);
    }

    public int GetHighScore()
    {
        return TopPlayer.highScore;
    }

    public string GetName()
    {
        return playerName;
    }

    public class TopPlayer
    {
        public static string highName;
        public static int highScore;
    }

}
