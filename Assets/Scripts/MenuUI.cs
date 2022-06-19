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
        //string n = (inputField.GetComponent<TextMeshProUGUI>().text);
        //Debug.Log("Input Field is " + n);

        //Error Message: "NullReferenceException: Object reference not set to an instance of an object
        dataManager.newPlayer.Name = inputField.GetComponent<TextMeshProUGUI>().text;
        
        Debug.Log("newPlayer.Name taken from input; Name is " + dataManager.newPlayer.Name);
        Debug.Log("Set Name button pressed" + dataManager.newPlayer.Name);
    }

}
