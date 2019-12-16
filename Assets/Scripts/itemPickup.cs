using UnityEngine;

public class itemPickup : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        pickup();
        
    }

    // Update is called once per frame
    void pickup()
    {
        //this.GetComponent<GlowObjectCmd>().enabled = false;
        Debug.Log("item is picked up");
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
