using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;

    bool isFocus = false;
    Transform player;

    public bool hasInteracted = false;

    float distance;

    public virtual void Interact()
    {

    }


    void Update()
    {        
        if (isFocus && !hasInteracted)
        {
            distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {

                hasInteracted = true;
                Debug.Log("Interacted with " + this.gameObject.name);
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
