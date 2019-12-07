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
    
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //left mouse
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //TRIGGER DIALOGUE ON OBJECT
                hit.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

                Debug.Log("we hit " + hit.collider.name + " " + hit.point);
                agent.SetDestination(hit.point);

                //anim
                this.GetComponent<Animator>().SetBool("is_walk", true);

                //move
                RemoveFocus();
            }

        }

        //right mouse
        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("we hit " + hit.collider.name + " " + hit.point);
                agent.SetDestination(hit.point);

                //anim
                this.GetComponent<Animator>().SetBool("is_walk", true);

                //move
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }

        }

        if (focus.Interacted())
        {
            RemoveFocus();
            this.GetComponent<Animator>().SetBool("is_walk", false);
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
            agent.stoppingDistance = newFocus.radius * 1f;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if( focus != null)
        {
            focus.OnDefocused();
        }
        
        agent.stoppingDistance = 0;
        focus = null;
    }


}
