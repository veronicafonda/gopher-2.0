using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    float DisplayText_speed = .05f;
    public TextMeshProUGUI nameText;
    public Text dialogueText;
    public TextMeshProUGUI dialogueText_UNUSABLE;

    public Animator animator;

    public static bool is_end;    

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        is_end = false;
    }



    public void StartDialogue (Dialogue dialogue)
    {
        
        if (dialogue.YesNoDialogue)
        {
            FindObjectOfType<sc_yes>().reset_clicked();
            //Debug.Log("YesNo is now true");
            animator.SetBool("DialogueYesNo", true);
        }
        else
        {
            //Debug.Log("Dialogue default");
            animator.SetBool("DialogueOpen", true);
        }

        //Debug.Log("Dialogue: " + dialogue.name);
        UI_Pause.pauseBool = true;

        //Judul dari text (Doesnt work somehow)
        //nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            //Debug.Log("Sentences: " + dialogue.sentences);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        FindObjectOfType<sc_cacing>().hide();
        FindObjectOfType<sc_cacing>().empty(true);

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence (string sentence)
    {
        //Debug.Log("Typing Sentence");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(DisplayText_speed);
        }
        FindObjectOfType<sc_cacing>().show();

    }

    public void EndDialogue()
    {
        if(FindObjectOfType<inventory_siblings>() != null)
            FindObjectOfType<inventory_siblings>().lower();
        is_end = true;
        animator.SetBool("DialogueOpen", false);
        animator.SetBool("DialogueYesNo", false);
        FindObjectOfType<sc_cacing>().hide();
        FindObjectOfType<sc_cacing>().empty(false);

        UI_Pause.pauseBool = false;
        sentences.Clear();
        //Debug.Log("End of Conversation ");        
    }
}
