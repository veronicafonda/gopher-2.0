using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    float DisplayText_speed = .05f;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

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
<<<<<<< HEAD
        if (dialogue.YesNoDialogue)
        {
            Debug.Log("YesNo is now true");
            animator.SetBool("DialogueYesNo", true);
        }
        else
        {
            Debug.Log("Dialogue default");
            animator.SetBool("DialogueOpen", true);
        }
        
=======
        is_end = false;   
        animator.SetBool("DialogueOpen", true);
>>>>>>> 1d97ed44086d28e9267a1c590bbfa4515d2e9a8f
        Debug.Log("Dialogue: " + dialogue.name);
        UI_Pause.pauseBool = true;

        //Judul dari text (Doesnt work somehow)
        //nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
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
        Debug.Log("Typing Sentence");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(DisplayText_speed);
        }

    }

    public void EndDialogue()
    {
        is_end = true;
        animator.SetBool("DialogueOpen", false);
        animator.SetBool("DialogueYesNo", false);
        UI_Pause.pauseBool = false;
<<<<<<< HEAD
        Debug.Log("End of Conversation ");
=======
        Debug.Log("End of Conversation");

>>>>>>> 1d97ed44086d28e9267a1c590bbfa4515d2e9a8f
    }
}
