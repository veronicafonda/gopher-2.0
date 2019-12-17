using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public int endingProgress = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("level progress = " + endingProgress);
        switch (endingProgress)
        {
            case 0:
                //player.GetComponent<Animator>().SetBool("is_lay", true);
                //StartCoroutine(WaitAndadvanced(2f));

                break;
            case 1:
                //player.GetComponent<Animator>().SetBool("is_lay", false);
                //player.GetComponent<Animator>().SetBool("is_jump", true);
                break;
            case 2:
                //player.GetComponent<Animator>().SetBool("is_jump", false);
                break;
            case 3:
                print("Grog SMASH!");
                break;
            case 4:
                print("Ulg, glib, Pblblblblb");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    public void onClickDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked");
    }
}
