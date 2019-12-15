using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sc_hero : MonoBehaviour
{
    float speed = 6f;

    public Camera cam;

    public Interactable focus;

    NavMeshAgent agent;

    float distance;

    public static int levelProgress;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        levelProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //left mouse
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && UI_Pause.pauseBool == false)
            {
                //TRIGGER DIALOGUE ON OBJECT
                if(hit.collider.gameObject.tag == "interactable")
                {
                    //hit.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                }                

                Debug.Log("we hit " + hit.collider.name + " " + hit.point);
                if(hit.collider.name == "floor")
                {
                    agent.stoppingDistance = 0;
                }
                agent.SetDestination(hit.point);

                //move
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }

        }

        if(focus != null)
        {
            distance = Vector3.Distance(focus.gameObject.transform.position, transform.position);
        }

        if ( focus != null && focus.Interacted() == true)
        {
            RemoveFocus();
            this.GetComponent<Animator>().SetBool("is_walk", false);
        }

        if(agent.velocity.magnitude < 1)
        {
            this.GetComponent<Animator>().SetBool("is_walk", false);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("is_walk", true);
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus !=null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
            agent.stoppingDistance = newFocus.radius * 0.5f;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if( focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }


}
