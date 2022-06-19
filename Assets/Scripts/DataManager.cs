using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public static string currentPlayer;

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
    public void SetHighScore()
    {
        if (IsHighScore())
        {
            HighScore.Score = CurrentPlayer.Score;
            HighScore.Name = CurrentPlayer.Name;
        }
        Debug.Log("The score is " + CurrentPlayer.Score);
        Debug.Log("The high score is " + HighScore.Score + ". Set by " + HighScore.Name);
    }

    // Compare newPlayer.Score to highScore.Score and return bool
    public bool IsHighScore()
    {
        bool isHighScore = false;
        if (CurrentPlayer.Score > HighScore.Score)
        {
            return true;
        }
        return isHighScore;
    }

    //Method to concatenate high score name and high score into a string
    public string HighScoreText()
    {
        string highScoreAndPlayer;

        highScoreAndPlayer = HighScore.Name + " : " + HighScore.Score;
        return highScoreAndPlayer;
    }
}

public static class CurrentPlayer
{
    private static string name;
    private static int score;

    public static string Name
    {
        get => name;
        set => name = value;
    }
    public static int Score
    {
        get => score;
        set => score = value;
    }
}


public static class HighScore
{
    private static string name = "Chris";
    private static int score = 1;

    public static string Name
    {
        get => name;
        set => name = value;
    }
    public static int Score
    {
        get => score;
        set => score = value;
    }
}
