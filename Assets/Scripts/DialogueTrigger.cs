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

    public int update_checker;
    public bool tuker;

    public void Start()
    {
        
        status_dialogue = 0;
        counter = dialogue.Count;
        update_checker = sc_hero.levelProgress;
        tuker = false;
    }

    private void Update()
    {
        if(status_dialogue < counter)
        {
            if (dialogue[status_dialogue].when < sc_hero.levelProgress)
            {
                status_dialogue++;
            }
        }
      
    }

    public void TriggerDialogue ()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);
        FindObjectOfType<inventory_siblings>().raised();
        if ( status_dialogue < counter)
        {   
            if(dialogue[status_dialogue].when == sc_hero.levelProgress)
            {
                update_checker = sc_hero.levelProgress;
                //Debug.Log("keluar +" + status_dialogue );
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[status_dialogue]);
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(default_dialogue);
            }

        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(default_dialogue);
        }

    }
}
