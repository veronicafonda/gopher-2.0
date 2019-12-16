using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;
    public int counter;

    bool isFocus = false;
    Transform player;
    public List<int> add_progress_when;
    public int status_interactable;

    public bool hasInteracted = false;

    float distance;


    public int test = 0;

    public virtual void Interact()
    {
        Debug.Log("keluar harusnya");
    }

    private void Start()
    {
        status_interactable = 0;
        counter = add_progress_when.Count;
    }

    void Update()
    {        
        if (isFocus && !hasInteracted)
        {
            distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                hasInteracted = true;                
                if (this.gameObject.GetComponent<DialogueTrigger>() != null)
                    this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                test++;
                if (status_interactable < counter )
                {   
                    if(add_progress_when[status_interactable] == sc_hero.levelProgress)
                    {
                        sc_hero.levelProgress++;
                        status_interactable++;
                        //Interact();
                    }
                }
                Interact();

            }

            //Debug.Log(distance + " " + (distance <= radius));

        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public bool Interacted()
    {             
        return hasInteracted;
    }
}
