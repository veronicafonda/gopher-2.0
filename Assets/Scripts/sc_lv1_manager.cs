using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class sc_lv1_manager : MonoBehaviour
{
    public GameObject player;
    public bool is_dialog;
    public int current_prog;
    public GameObject black_panel;


    //tambahan

    public GameObject stuart_sleep;
    public GameObject stuart_stand;

    public GameObject main_camera;

    public GameObject canvas_letter;
    public GameObject canvas_tuts;

    public GameObject keranjang;
    public GameObject baju1;
    public GameObject baju2;
    public GameObject baju3;
    public GameObject tangga;
    public GameObject kunci;

    public GameObject hatch;

    public GameObject button_letter;
    public GameObject text_letter;

    public bool is_run;
    public bool is_run2;
    public bool is_run3;
    public bool is_run4;
    public bool is_tuts;


    // Start is called before the first frame update
    void Start()
    {
        UI_Pause.pauseBool = true;

        FindObjectOfType<AudioManager>().Play("bgm");
        stuart_stand.SetActive(false);
        player.SetActive(false);
        current_prog = 0;
        is_dialog = true;

        is_run = true;
        is_run2 = true;
        is_run3 = true;
        is_run4 = true;
        is_tuts = false;

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
                    FindObjectOfType<AudioManager>().Play("snore");
                    is_dialog = false;
                }

                main_camera.GetComponent<GlowController>().enabled = true;
                StartCoroutine(WaitAndadvanced_1());
                //sc_hero.levelProgress++;

                break;
            case 1:

                if (!is_tuts)
                {
                    canvas_tuts.SetActive(true);
                    is_tuts = true;
                    UI_Pause.pauseBool = false;
                }
                if (is_dialog)
                {
                    
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    //Debug.Log("Press 'right click' on the floor to move.");
                    is_dialog = false;
                }

                black_panel.GetComponent<Animator>().SetBool("is_fade", false);
                black_panel.GetComponent<Animator>().SetBool("is_done", true);                

                sc_hero.levelProgress++;

                break;
            case 2:

                main_camera.GetComponent<GlowController>().enabled = true;
                if (is_dialog)
                {                    
                    //Debug.Log("Press 'right click' on the glowing to object to interact.");
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }

                break;
            case 3:
                StartCoroutine(WaitAndadvanced_2());
                break;
            case 4:
                black_panel.GetComponent<Animator>().SetBool("is_fade", false);
                black_panel.GetComponent<Animator>().SetBool("is_done", true);
                break;
            case 5:
                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }
      
                main_camera.GetComponent<GlowController>().enabled = true;
                break;
            case 10:
                StartCoroutine(WaitAndadvanced_3());
                break;
            case 11:
                StartCoroutine(WaitAndadvanced_4());
                SceneManager.LoadScene("level2");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
    
    private IEnumerator WaitAndadvanced_1()
    {

        if (is_run)
        {
            is_run = false;
            yield return new WaitForSeconds(1f);
            FindObjectOfType<AudioManager>().Stop("snore");
            FindObjectOfType<AudioManager>().Mute("snore");

            yield return new WaitForSeconds(1f);            
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(1f);
            stuart_stand.SetActive(true);
            stuart_sleep.SetActive(false);
            yield return new WaitForSeconds(1f);
            sc_hero.levelProgress++;
            //Debug.Log("level = " + sc_hero.levelProgress);
            
        }
        

        yield return null;        
    }

    private IEnumerator WaitAndadvanced_2()
    {

        if (is_run2)
        {
            is_run2 = false;
            UI_Pause.pauseBool = true;
            yield return new WaitForSeconds(2f);
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(1f);

            stuart_stand.SetActive(false);
            player.SetActive(true);          
            
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            FindObjectOfType<AudioManager>().Play("letter");
            FindObjectOfType<AudioManager>().Play("surat");
            
            canvas_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = false;
            text_letter.SetActive(false);
            yield return new WaitForSeconds(3f);
            sc_hero.levelProgress = 4;
            UI_Pause.pauseBool = false;
            text_letter.SetActive(true);
            button_letter.GetComponent<Button>().interactable = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }


        yield return null;
    }

    private IEnumerator WaitAndadvanced_3()
    {

        if (is_run3)
        {
            is_run3 = false;
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(3f);                        
        }


        yield return null;
    }

    private IEnumerator WaitAndadvanced_4()
    {

        if (is_run4)
        {
            is_run4 = false;
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(4f);

            SceneManager.LoadScene("Ending");
            
        }


        yield return null;
    }

    public void onClickDialogueYes()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        if (sc_hero.levelProgress == 5)
        {
            FindObjectOfType<AudioManager>().Play("baju1");
            keranjang.GetComponent<itemPickup>().pickup();
        }
        if (sc_hero.levelProgress == 6)
        {
            FindObjectOfType<AudioManager>().Play("baju1");
            baju1.GetComponent<itemPickup>().pickup();
        }
        else if (sc_hero.levelProgress == 7)
        {
            FindObjectOfType<AudioManager>().Play("baju1");
            baju2.GetComponent<itemPickup>().pickup();
        }
        else if (sc_hero.levelProgress == 8)
        {
            FindObjectOfType<AudioManager>().Play("baju1");
            baju3.GetComponent<itemPickup>().pickup();
        }
        else if (sc_hero.levelProgress == 9)
        {
            FindObjectOfType<AudioManager>().Play("kunci");

            tangga.GetComponent<sc_lv1_tangga>().pickup();
            kunci.GetComponent<itemPickup>().pickup();
        }
        else if (sc_hero.levelProgress == 10)
        {
            hatch.GetComponent<sc_lv1_hatch>().pickup();
        }

        Debug.Log("Dialogue Clicked Yes");
        sc_hero.levelProgress++;

    }

    public void onClickDialogueNo()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked No");
    }

    public void level1_letter()
    {
        canvas_letter.SetActive(false);
        FindObjectOfType<AudioManager>().Mute("letter");
        FindObjectOfType<AudioManager>().Stop("letter");
        sc_hero.levelProgress++;

    }

    public void level_tuts()
    {
        canvas_tuts.SetActive(false);
    }

}
