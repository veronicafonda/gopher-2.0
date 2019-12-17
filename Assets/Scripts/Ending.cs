using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    int endingProgress = 0;

    public Animator dialogueBoxAnim;

    int ui_multiplier = -5;
    int ui_multiplier2 = -12;
    public GameObject uiPlace;
    bool is_dialog = false;
    bool is_nicole = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("level progress = " + endingProgress);
        switch (endingProgress)
        {
            case 0:
                is_dialog = true;
                endingProgress++;
                break;
            case 1:
                if (is_dialog)
                {
                    uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier, uiPlace.transform.position.y, uiPlace.transform.position.z);
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    Debug.Log("cas1");
                    endingProgress++;
                    is_dialog = false;
                }
                break;
            case 2:
                jeda();
                break;
            case 3:
                
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
            default:
                
                break;
        }
    }

    private IEnumerator endingProgIncrement(float wait)
    {
        Debug.Log("WAIT");
        yield return new WaitForSeconds(wait);
        if (is_nicole == false)
            uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier, uiPlace.transform.position.y, uiPlace.transform.position.z);
        else
            uiPlace.transform.position = new Vector3(transform.position.x + ui_multiplier2, uiPlace.transform.position.y, uiPlace.transform.position.z);

        if (dialogueBoxAnim.GetBool("DialogueOpen") == false)
        {
            endingProgress++;
        }
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public void onClickDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked");
        //endingProgress++;
    }

    void jeda()
    {
        is_dialog = true;
        is_nicole = !is_nicole;
        if (dialogueBoxAnim.GetBool("DialogueOpen") == false)
        {
            endingProgress++;
        }
    }

    void caseGanjil()
    {
        if (is_dialog)
        {
            StartCoroutine(endingProgIncrement(.5f));

            is_dialog = false;
            
        }
    }
}
