using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;
    public List<Dialogue> dialogue;
    public int status_dialogue;
    public int counter;
    public Dialogue default_dialogue;


    public void Start()
    {
        status_dialogue = 0;
        counter = dialogue.Count;

    }

    public void TriggerDialogue ()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);

        if ( status_dialogue < counter)
        {   
            if(dialogue[status_dialogue].when == sc_hero.levelProgress)
            {
                //Debug.Log("keluar +" + status_dialogue );
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[status_dialogue]);
                
            }
            status_dialogue++;
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(default_dialogue);
        }
    }
}
