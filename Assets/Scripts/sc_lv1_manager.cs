using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public GameObject canvas_tuts1;
    public GameObject canvas_tuts2;
    public GameObject canvas_letter;


    public bool is_run;
    public bool is_run2;



    // Start is called before the first frame update
    void Start()
    {
        stuart_stand.SetActive(false);
        player.SetActive(false);
        current_prog = 0;
        is_dialog = true;

        is_run = true;
        is_run2 = true;

    }

    // Update is called once per frame
    void Update()
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
                main_camera.GetComponent<GlowController>().enabled = false;
                StartCoroutine(WaitAndadvanced_1(1f,1));
                //sc_hero.levelProgress++;

                break;
            case 1:

                if (is_dialog)
                {
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    Debug.Log("Press 'right click' on the floor to move.");
                    is_dialog = false;
                }

                black_panel.GetComponent<Animator>().SetBool("is_fade", false);
                black_panel.GetComponent<Animator>().SetBool("is_done", true);

                if (Input.GetMouseButtonDown(1))
                {
                    Ray ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && UI_Pause.pauseBool == false)
                    {
                        if (hit.collider.name == "floor")
                        {
                            Debug.Log("success 1");
                            sc_hero.levelProgress++;
                            //this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                        }
                    }

                }

                break;
            case 2:

                main_camera.GetComponent<GlowController>().enabled = true;
                if (is_dialog)
                {
                    Debug.Log("Press 'right click' on the glowing to object to interact.");
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    is_dialog = false;
                }

                if (Input.GetMouseButtonDown(1))
                {
                    Ray ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && UI_Pause.pauseBool == false)
                    {
                        if (hit.collider.name == "wardrobe")
                        {
                            Debug.Log("success 2");

                        }
                    }

                }
                break;
            case 3:
                StartCoroutine(WaitAndadvanced_2(2f, 4));
                break;
            case 4:

                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
    
    private IEnumerator WaitAndadvanced_1(float waitTime,int level)
    {

        if (is_run)
        {
            yield return new WaitForSeconds(waitTime);
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(1f);
            stuart_stand.SetActive(true);
            stuart_sleep.SetActive(false);
            yield return new WaitForSeconds(1f);
            sc_hero.levelProgress = level;
            Debug.Log("level = " + sc_hero.levelProgress);
            is_run = false;
        }
        

        yield return null;        
    }

    private IEnumerator WaitAndadvanced_2(float waitTime, int level)
    {

        if (is_run2)
        {
            yield return new WaitForSeconds(waitTime);
            black_panel.GetComponent<Animator>().SetBool("is_fade", true);
            yield return new WaitForSeconds(1f);
            player.SetActive(true);
            stuart_stand.SetActive(false);
            yield return new WaitForSeconds(1f);
            sc_hero.levelProgress = level;
            Debug.Log("level = " + sc_hero.levelProgress);
            canvas_letter.SetActive(true);
            is_run = false;
        }


        yield return null;
    }

    public void onClickDialogueYes()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked Yes");
    }

    public void onClickDialogueNo()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        Debug.Log("Dialogue Clicked No");
    }

    public void level1_letter()
    {
        canvas_letter.SetActive(false);
        sc_hero.levelProgress++;
    }

}
