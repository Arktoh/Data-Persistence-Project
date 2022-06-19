using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject DataManager;
    public GameObject inputField;
    Player nPlayer;
    Player hScore;

    public void Start()
    {
        //DataManager dataManager = new DataManager();
        //dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        //Debug.Log("MenuUI.cs" + newPlayer.GetType() + " newPlayer Instantiated as a new " + " with a value of " + newPlayer.Name + " and " + newPlayer.Score);
        //dataManager = DataManager.GetComponent<DataManager>();
        //nPlayer = dataManager.newPlayer;
        //Player newPlayer = DataManager.GetComponent<DataManager>().newPlayer;
        //Debug.Log("MenuUI - newPlayer " + nPlayer.Name + " : " + nPlayer.Score);
        //nPlayer.Name = dataManager.newPlayer.Name;
        //nPlayer.Score = dataManager.newPlayer.Score;



        DataManager = GameObject.Find("DataManager");
        dataManager = DataManager.GetComponent<DataManager>();
        nPlayer = dataManager.newPlayer;
        hScore = dataManager.highScore;

        //Error Message: "NullReferenceException: Object reference not set to an instance of an object
        Debug.Log(hScore.Score);
        //Debug.Log("MenuUI - newPlayer " + dataManager.newPlayer.Name + " : " + dataManager.newPlayer.Score);        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //original code to quit Unity player
#endif
    }

    public void SetName()
    {
        //string n = (inputField.GetComponent<TextMeshProUGUI>().text);
        //Debug.Log("Input Field is " + n);

        //Error Message: "NullReferenceException: Object reference not set to an instance of an object
        dataManager.newPlayer.Name = inputField.GetComponent<TextMeshProUGUI>().text;
        
        Debug.Log("newPlayer.Name taken from input; Name is " + dataManager.newPlayer.Name);
        Debug.Log("Set Name button pressed" + dataManager.newPlayer.Name);
    }

}
