using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 10f;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;


    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Debug.Log("stio");
                hasInteracted = true;
                Interacted();
            }
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
