using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator stuartNicole;
    public Animator mainMenu;
    public GameObject pressKey;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("mmbgm");
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

    public void exitClick()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
    public void creditsClick()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void pressAnykey()
    {
        stuartNicole.SetBool("afterClick", true);
        mainMenu.SetBool("afterClick", true);
        mainMenu.SetBool("toMainMenu", true);

    }
}
