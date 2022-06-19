using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;    
    private bool m_GameOver = false;

    public DataManager dataManager;
    public ScriptableObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

        Debug.Log("Starting a new game. Player name is: " + CurrentPlayer.Name);

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        HighScoreText.text = $"Best Score : {dataManager.HighScoreText()}";
    }

    private void Update()
    { 
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void AddPoint(int point)
    {
        CurrentPlayer.Score += point;
        ScoreText.text = $"Score : {CurrentPlayer.Score}";
    }

    public void GameOver()
    {
        m_GameOver = true;

        GameOverText.SetActive(true);
        dataManager.SetHighScore();
        HighScoreText.text = $"Best Score : {HighScore.Name} {HighScore.Score}";
        CurrentPlayer.Score = 0;
        Debug.Log($"CurrentPlayer.Score reset to {CurrentPlayer.Score}");
    }
}
