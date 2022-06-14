using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public Player newPlayer;
    public Player highScore;

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

    public void Start()
    {
        //Instantiate newPlayer Player Object
        Player newPlayer = new()
        {
            Name = "Blank",
            Score = 0
        };
        Debug.Log(newPlayer.GetType() + " newPlayer Instantiated as a new " + " with a value of " + newPlayer.Name + " and " + newPlayer.Score);

        //Instantiate highScore Player Object
        Player highScore = new()
        {
            Name = "Bob",
            Score = 5
        };
        Debug.Log(highScore.GetType() + " highScore Instantiated as a new " + " with a value of " + highScore.Name + " and " + highScore.Score);
    }

    // Method called when m_Gameover = true to collect score, and update session and JSON file with high score
    public void SetScore()
    {
        if (IsHighScore())
        {
            highScore.Score = newPlayer.Score;
            highScore.Name = newPlayer.Name;
        }
        Debug.Log("The score is " + newPlayer.Score);
        Debug.Log("The high score is " + highScore.Score);
    }

    // Compare newPlayer.Score to highScore.Score and return bool
    public bool IsHighScore()
    {
        bool isHighScore = false;
        if (newPlayer.Score > highScore.Score)
        {
            return true;
        }
        return isHighScore;
    }

    //Method to concatenate high score name and high score into a string
    public string HighScoreText()
    {
        string highScoreAndPlayer;

        highScoreAndPlayer = highScore.Name + " : " + highScore.Score;
        return highScoreAndPlayer;
    }
}
