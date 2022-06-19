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
    public GameObject DataManager;
    public DataManager dataManager;
    
    public GameObject inputField;
        
    public void Start()
    {
        DataManager = GameObject.Find("DataManager");
        dataManager = DataManager.GetComponent<DataManager>();       
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
        CurrentPlayer.Name = inputField.GetComponent<TextMeshProUGUI>().text;
        Debug.Log("Set Name button pressed " + CurrentPlayer.Name);
    }

}
