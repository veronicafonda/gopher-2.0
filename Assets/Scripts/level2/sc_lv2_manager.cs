using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class sc_lv2_manager : MonoBehaviour
{
    public GameObject player;
    public bool is_dialog;
    public int current_prog;
    public GameObject black_panel;

    public GameObject canvas_letter;
    public GameObject button_letter;
    public GameObject text_letter;

    //tambahan

    public bool is_run;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bgm");
        current_prog = 0;
        is_dialog = true;

        //tambahan
        is_run = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current_prog != sc_hero.levelProgress)
        {
            current_prog = sc_hero.levelProgress;
            is_dialog = true;
        }

        //Debug.Log("level progress = " + sc_hero.levelProgress);

        switch (sc_hero.levelProgress)
        {
            case 0:

                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    //Where is Nicole..? Maybe she left another letter here too.
                    is_dialog = false;
                }

                break;
            case 1:

                StartCoroutine(wait_1());

                break;
            case 2:

                StartCoroutine(wait_1());

                break;
            case 3:

                StartCoroutine(wait_1());

                break;
            case 4:

                StartCoroutine(wait_1());

                break;
            case 5:

                StartCoroutine(wait_1());

                break;
            case 6:

                StartCoroutine(wait_1());

                break;

            default:
                print("default");
                break;
        }
    }

    private IEnumerator wait_1()
    {

        if (is_run)
        {
            is_run = false;
            UI_Pause.pauseBool = true;
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(1f);

            FindObjectOfType<AudioManager>().Play("letter");
            FindObjectOfType<AudioManager>().Play("surat");

            canvas_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = false;
            text_letter.SetActive(false);
            yield return new WaitForSeconds(8f);

            UI_Pause.pauseBool = false;
            text_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

        }
        yield return null;
    }


    public void level2_letter()
    {
        canvas_letter.SetActive(false);
        FindObjectOfType<AudioManager>().Mute("letter");
        FindObjectOfType<AudioManager>().Stop("letter");
        sc_hero.levelProgress++;

    }
}
