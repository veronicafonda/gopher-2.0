using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("staraasdasdsa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startClick()
    {
        SceneManager.LoadScene("level1_new");
        Debug.Log("Start");
    }

    public void optionsClick()
    {

    }

    public void exitClick()
    {

    }
    
    public void creditsClick()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
