using UnityEngine;
using UnityEngine.UI;

public class sc_lv3_gramaphone : Interactable
{
    public GameObject item;

    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        
        FindObjectOfType<sc_lv3_manager>().canvas_lagu_display();
        //pickup();
    }

    // Update is called once per frame
    public void pickup()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        FindObjectOfType<OpenCloseBag>().enabled_bag();
    }
}
