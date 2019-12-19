using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ending : MonoBehaviour
{

    public bool is_dialog;
    public int current_prog;

    public Animator dialogueBoxAnim;

    int ui_multiplier = -5;
    int ui_multiplier2 = -12;

    public GameObject uiPlace;

    bool is_nicole = true;


    //tambahan bego
    public bool is_run;

    // Start is called before the first frame update
    void Start()
    {
        current_prog = 0;
        is_dialog = true;

        is_run = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current_prog != sc_hero.levelProgress)
        {
            //Debug.Log("level progress = " + sc_hero.levelProgress);
            current_prog = sc_hero.levelProgress;
            is_dialog = true;
        }

        Debug.Log("level progress = " + sc_hero.levelProgress);

        switch (sc_hero.levelProgress)
        {
            case 0:

                if (is_dialog)
                {
                    FindObjectOfType<AudioManager>().Play("bgm");
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;                    
                }
                jeda();

                break;
            case 1:

                if (is_dialog)
                {
                    uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier, uiPlace.transform.position.y, uiPlace.transform.position.z);
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }
                jeda();
                break;
            case 2:
                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }
                //jeda();
                break;
            case 3:
                //Debug.Log("cas3");
                caseGanjil();
                break;
            case 4:
                jeda();
                break;
            case 5: 
                caseGanjil();
                break;
            case 6:
                jeda();
                break;
            case 7: 
                caseGanjil();
                break;
            case 8:
                jeda();
                break;
            case 9: 
                caseGanjil();
                break;
            case 10:
                jeda();
                break;
            case 11: 
                caseGanjil();
                break;
            case 12:
                jeda();
                break;
            case 13: 
                caseGanjil();
                break;
            case 14:
                jeda();
                break;
            case 15: 
                caseGanjil();
                break;
            case 16:
                uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
                jeda();
                break;
            case 17: 
                caseGanjil();
                break;
            case 18:
                jeda();
                break;
            case 19: 
                caseGanjil();
                break;
            case 20:
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                
                break;
        }
    }

    private IEnumerator endingProgIncrement(float wait)
    {
        
        if (is_dialog)
        {
            is_dialog = false;
            Debug.Log("Masuk Corotin If");
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Debug.Log("is-nicole " + is_nicole);
            if (is_nicole != false)
            {
                uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier, uiPlace.transform.position.y, uiPlace.transform.position.z);
            }
            else
            {
                uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);
            }
            sc_hero.levelProgress++;

            yield return new WaitForSeconds(wait);
            


        }

        yield return null;
    }

    private IEnumerator waitStupid()
    {
        if (is_run)
        {
            is_run = false;
            yield return new WaitForSeconds(1f);
            sc_hero.levelProgress++;
        }
        yield return null;
        
    }

    public void onClickDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked");
        //endingProgress++;
    }

    void jeda()
    {
        //is_nicole = !is_nicole;
        Debug.Log(dialogueBoxAnim.GetBool("DialogueOpen"));
        if (!dialogueBoxAnim.GetBool("DialogueOpen"))
        {
            StartCoroutine(waitStupid());
        }
        
    }

    void caseGanjil()
    {
        StartCoroutine(endingProgIncrement(.5f));
    }
}
