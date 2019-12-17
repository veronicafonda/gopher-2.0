using UnityEngine;
using UnityEngine.UI;

public class itemPickup : Interactable
{
    public GameObject item;

    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        pickup();
    }

    // Update is called once per frame
    void pickup()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        Destroy(item);
    }
}
