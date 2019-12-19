using UnityEngine;
using UnityEngine.UI;

public class sc_sheet_music : Interactable
{
    public GameObject item;
    public bool is_taken = false;

    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();

        pickup();
    }

    // Update is called once per frame
    public void pickup()
    {
        Debug.Log("Picking up " + item.name);
        

        if (!is_taken && sc_hero.levelProgress == 2)
        {
            bool wasPickedUp = Inventory.instance.Add(item);

            FindObjectOfType<OpenCloseBag>().enabled_bag();
            is_taken = true;
            FindObjectOfType<AudioManager>().Play("surat");
            FindObjectOfType<sc_lv3_manager>().set_part();
        }
    }
}
