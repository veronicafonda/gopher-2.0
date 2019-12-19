using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator stuartNicole;
    public Animator mainMenu;
    public Animator credits;
    public GameObject pressKey;
    public GameObject creditsBlackScreen;


    // Start is called before the first frame update
    void Start()
    {
        creditsBlackScreen.SetActive(false);
        FindObjectOfType<AudioManager>().Play("mmbgm");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            credits.SetBool("isCredits", false);
            creditsBlackScreen.SetActive(false);
            StopAllCoroutines();
        }
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
        Debug.Log("Creditss");
        creditsBlackScreen.SetActive(true);
        credits.SetBool("isCredits", true);
        StartCoroutine(waitAnim(17f));
    }

    private IEnumerator waitAnim(float wait)
    { 
        yield return new WaitForSeconds(wait);
        creditsBlackScreen.SetActive(false);
        credits.SetBool("isCredits", false);
    }

    public void pressAnykey()
    {
        stuartNicole.SetBool("afterClick", true);
        mainMenu.SetBool("afterClick", true);
        mainMenu.SetBool("toMainMenu", true);

    }
}
