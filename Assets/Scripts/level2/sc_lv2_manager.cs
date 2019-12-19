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

    public GameObject arrow;
    public GameObject gelas;
    public GameObject kettle;
    public GameObject faucet;
    public GameObject fireplace;



    public bool is_run;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bgm");
        FindObjectOfType<AudioManager>().Play("jem");
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
            Debug.Log("level progress = " + sc_hero.levelProgress);
            current_prog = sc_hero.levelProgress;
            is_dialog = true;
        }

        

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


                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }
                break;
            case 8:

                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }
                break;
            case 9:

                break;
            case 10:

                break;
            case 11:

                break;
            case 12:

                break;
            case 13:

                break;
            case 14:
                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }
                break;
            case 15:

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
            yield return new WaitForSeconds(2f);
            FindObjectOfType<AudioManager>().Stop("jem");
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            FindObjectOfType<AudioManager>().Play("surat");

            yield return new WaitForSeconds(1f);

            FindObjectOfType<AudioManager>().Play("letter");

            canvas_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = false;
            text_letter.SetActive(false);
            //11
            yield return new WaitForSeconds(11f);
            FindObjectOfType<AudioManager>().Play("jem");

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
            arrow.SetActive(true);
            FindObjectOfType<sc_map>().destroyed();
            //FindObjectOfType<AudioManager>().Play("baju1");
            //keranjang.GetComponent<itemPickup>().pickup();
        }
        else if (sc_hero.levelProgress == 6)
        {
            FindObjectOfType<AudioManager>().Play("kunci");
            gelas.GetComponent<sc_lv2_gelas>().pickup();
        }
        else if (sc_hero.levelProgress == 7)
        {
            FindObjectOfType<AudioManager>().Play("kettle");
            kettle.GetComponent<itemPickup>().pickup();
        }
        else if (sc_hero.levelProgress == 8)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            faucet.GetComponent<sc_lv2_faucet>().pickup();
        }
        else if (sc_hero.levelProgress == 9)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            FindObjectOfType<sc_firedown>().reduce1();
            fireplace.GetComponent<sc_lv2_fireplace>().pickup();
        }
        else if (sc_hero.levelProgress == 10)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            faucet.GetComponent<sc_lv2_faucet>().pickup();
        }
        else if (sc_hero.levelProgress == 11)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            FindObjectOfType<sc_firedown>().reduce2();
            fireplace.GetComponent<sc_lv2_fireplace>().pickup();
        }
        else if (sc_hero.levelProgress == 12)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            faucet.GetComponent<sc_lv2_faucet>().pickup();
        }
        else if (sc_hero.levelProgress == 13)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            FindObjectOfType<sc_firedown>().reduce3();
            fireplace.GetComponent<sc_lv2_fireplace>().pickup();
        }
        else if (sc_hero.levelProgress == 13)
        {
            FindObjectOfType<AudioManager>().Play("fill");
            FindObjectOfType<sc_firedown>().reduce3();
            fireplace.GetComponent<sc_lv2_fireplace>().pickup();
        }
        else if (sc_hero.levelProgress == 14)
        {
            SceneManager.LoadScene("level3");
        }


        Debug.Log("Dialogue Clicked Yes");
        sc_hero.levelProgress++;

    }

    public void onClickDialogueNo()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked No");
    }


    public void level2_letter()
    {
        canvas_letter.SetActive(false);
        FindObjectOfType<AudioManager>().Mute("letter");
        FindObjectOfType<AudioManager>().Stop("letter");
        sc_hero.levelProgress++;

    }
}
