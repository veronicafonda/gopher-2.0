using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class sc_lv3_manager : MonoBehaviour
{
    public GameObject player;
    public bool is_dialog;
    public int current_prog;
    public GameObject black_panel;

    public GameObject canvas_letter;
    public GameObject button_letter;
    public GameObject text_letter;

    public GameObject lagu;
    public GameObject twilight;



    //tambahan

    public bool is_run;

    public GameObject letter;
    public GameObject sofa;
    public GameObject mug;
    public GameObject vase;
    public GameObject bookcase;
    public GameObject hat;

    public GameObject tape;


    public bool is_complete;
    public int complete;
    


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bgm");
        //FindObjectOfType<AudioManager>().Play("jem");
        current_prog = 0;
        is_dialog = true;

        is_complete = false;
        complete = 0;

        //tambahan
        is_run = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current_prog != sc_hero.levelProgress)
        {
            Debug.Log("level progress = " + sc_hero.levelProgress);
            current_prog = sc_hero.levelProgress;
            is_dialog = true;
        }
        Debug.Log("level progress = " + sc_hero.levelProgress);
        //Debug.Log("level progress = " + sc_hero.levelProgress);

        switch (sc_hero.levelProgress)
        {
            case 0:

                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }

                break;
            case 1:

                StartCoroutine(wait_1());

                break;
            case 2:

                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    
                    FindObjectOfType<AudioManager>().Play("barang");
                    letter.GetComponent<sc_letterv3>().pickup();
                    is_dialog = false;

                }

                if (complete > 4 && !is_complete)
                {
                    sc_hero.levelProgress++;
                    is_complete = true;
                }


                break;
            case 3:


                break;
            case 4:


                break;
            case 5:


                break;
            case 6:


                break;

            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    private IEnumerator wait_1()
    {

        if (is_run)
        {
            is_run = false;
            UI_Pause.pauseBool = true;
            yield return new WaitForSeconds(2f);
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            FindObjectOfType<AudioManager>().Play("surat");

            yield return new WaitForSeconds(1f);

            FindObjectOfType<AudioManager>().Play("letter");

            canvas_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = false;
            text_letter.SetActive(false);
            yield return new WaitForSeconds(1f);

            UI_Pause.pauseBool = false;
            text_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

        }
        yield return null;
    }

    public void onClickDialogueYes()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        if (sc_hero.levelProgress == 3)
        {
            FindObjectOfType<AudioManager>().Play("barang");
            tape.GetComponent<sc_lv3_tape>().pickup();
        }

        if (sc_hero.levelProgress == 5)
        {
            SceneManager.LoadScene("Ending");

        }

        //Debug.Log("Dialogue Clicked Yes");
        sc_hero.levelProgress++;

    }

    public void onClickDialogueNo()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        //Debug.Log("Dialogue Clicked No");
    }


    public void level3_letter()
    {
        canvas_letter.SetActive(false);
        FindObjectOfType<AudioManager>().Mute("letter");
        FindObjectOfType<AudioManager>().Stop("letter");
        sc_hero.levelProgress++;

    }

    public void set_part()
    {
        complete++;
    }

    public int get_part()
    {
        return complete;
    }

    //dawn
    //daylight
    //dusk
    //twilight

    public void play_dawn()
    {
        FindObjectOfType<AudioManager>().Stop("bgm");
        FindObjectOfType<AudioManager>().Stop("lagu1");
        FindObjectOfType<AudioManager>().Stop("lagu2");
        FindObjectOfType<AudioManager>().Stop("lagu3");
        FindObjectOfType<AudioManager>().Stop("lagu4");
        FindObjectOfType<AudioManager>().Play("lagu1");

        lagu.SetActive(false);

}
    public void play_daylight()
    {
        FindObjectOfType<AudioManager>().Stop("bgm");
        FindObjectOfType<AudioManager>().Stop("lagu1");
        FindObjectOfType<AudioManager>().Stop("lagu2");
        FindObjectOfType<AudioManager>().Stop("lagu3");
        FindObjectOfType<AudioManager>().Stop("lagu4");
        FindObjectOfType<AudioManager>().Play("lagu2");

        lagu.SetActive(false);

    }
    public void play_dusk()
    {
        FindObjectOfType<AudioManager>().Stop("bgm");
        FindObjectOfType<AudioManager>().Stop("lagu1");
        FindObjectOfType<AudioManager>().Stop("lagu2");
        FindObjectOfType<AudioManager>().Stop("lagu3");
        FindObjectOfType<AudioManager>().Stop("lagu4");
        FindObjectOfType<AudioManager>().Play("lagu3");

        lagu.SetActive(false);

    }
    public void play_twilight()
    {
        FindObjectOfType<AudioManager>().Stop("bgm");
        FindObjectOfType<AudioManager>().Stop("lagu1");
        FindObjectOfType<AudioManager>().Stop("lagu2");
        FindObjectOfType<AudioManager>().Stop("lagu3");
        FindObjectOfType<AudioManager>().Stop("lagu4");
        FindObjectOfType<AudioManager>().Play("lagu4");

        if (sc_hero.levelProgress == 4)
        {
            FindObjectOfType<AudioManager>().Play("jeruji");
            FindObjectOfType<sc_jeruji>().jeruji_open();
            sc_hero.levelProgress++;
        }

        lagu.SetActive(false);
    }

    public void play_back()
    {
        lagu.SetActive(false);
    }

    public void canvas_lagu_display()
    {
        lagu.SetActive(true);
        if(sc_hero.levelProgress >= 4)
        {
            twilight.SetActive(true);
        }
        else
        {
            twilight.SetActive(false);
        }
    }

}
