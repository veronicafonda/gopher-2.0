using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ending : MonoBehaviour
{
    int counter = 0;

    public bool is_dialog;
    public int current_prog;
    bool firstime;

    public Animator dialogueBoxAnim;
    public Animator creditsAnim;

    public bool afterCredits;

    int ui_multiplier = -5;
    int ui_multiplier2 = -12;

    public GameObject uiPlace;

    bool is_nicole = true;


    //tambahan bego
    public bool dialogBoxSwitch;

    // Start is called before the first frame update
    void Start()
    {
        firstime = true;
        current_prog = 0;
        is_dialog = true;
        counter = 0;
        dialogBoxSwitch = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("level progress = " + counter);

        switch (counter)
        {
            case 0:
                Debug.Log("NICOLE");
                
                if (is_dialog)
                {
                    FindObjectOfType<AudioManager>().Play("bgm");
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;                    
                }
                break;
            case 1:
                dialogBoxSwitch = false;
                break;
            case 2:
                
                is_nicole = !is_nicole;
                Debug.Log(counter + " STUART");
                jeda();
                is_dialog = true;
                break;
            case 3:
                dialogBoxSwitch = false;
                break;
            case 4:
                is_nicole = !is_nicole;
                Debug.Log(counter + " NICOLE");
                jeda();
                
                break;
            case 5:
                if (is_dialog)
                {
                    is_dialog = !is_dialog;
                    dialogBoxSwitch = false;
                    uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
                }
                is_nicole = !is_nicole;
                Debug.Log(counter + " STUART");
                
                break;
            case 6:
                dialogBoxSwitch = false;
                break;
            case 7:
                is_nicole = !is_nicole;
                Debug.Log(counter + " NICOLE");
                jeda();
                break;
            case 8:
                is_dialog = true;
                break;
            case 9:
                if (is_dialog)
                {
                    is_dialog = !is_dialog;
                    dialogBoxSwitch = false;
                    uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
                }
                is_nicole = !is_nicole;
                Debug.Log(counter + " STUART");
                break;
            case 10:
                dialogBoxSwitch = false;
                break;
            case 11:
                is_nicole = !is_nicole;
                Debug.Log(counter + " NICOLE");
                jeda();
                break;
            case 12:
                is_dialog = true;
                break;
            case 13:
                is_dialog = true;
                break;
            case 14:
                if (is_dialog)
                {
                    is_dialog = !is_dialog;
                    dialogBoxSwitch = false;
                    uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
                }
                is_nicole = !is_nicole;
                Debug.Log(counter + " STUART");
                jeda();
                break;
            case 15:
                dialogBoxSwitch = false;
                break;
            case 16:
                is_nicole = !is_nicole;
                Debug.Log(counter + " NICOLE");
                jeda();
                break;
            case 17: 

                break;
            case 18:
                is_dialog = true;
                break;
            case 19:
                if (is_dialog)
                {
                    is_dialog = !is_dialog;
                    dialogBoxSwitch = false;
                    uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
                }
                is_nicole = !is_nicole;
                Debug.Log(counter + " STUART");
                jeda();
                break;
            case 20:
                jeda();
                break;
            case 21:
                if (firstime)
                {
                    firstime = false;
                    StartCoroutine(waitAnim());
                }
                
                break;
            case 22:
                jeda();
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                
                break;
        }

    }
    
    private IEnumerator waitAnim()
    {
        creditsAnim.SetBool("isCredits", true);
        yield return new WaitForSeconds(16f);
        counter++;
    }

    private IEnumerator waitStupid()
    {
        if (dialogBoxSwitch)
        {
            dialogBoxSwitch = false;
            yield return new WaitForSeconds(1f);
            sc_hero.levelProgress++;
        }
        yield return null;
        
    }

    public void onClickDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        //Debug.Log("Dialogue Clicked");
        counter++;
    }

    void jeda()
    {
        Debug.Log("Masuk Jeda");
        if (!dialogBoxSwitch)
        {
            if (is_nicole != false || counter == 4 || counter == 7 || counter == 11 || counter == 16)
            {
                uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier, uiPlace.transform.position.y, uiPlace.transform.position.z);
            }
            else if (is_nicole == false || counter == 2 || counter == 5 || counter == 9 || counter == 14 || counter == 19)
            {
                uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
            }
            dialogBoxSwitch = !dialogBoxSwitch;
        }
        
    }
}
