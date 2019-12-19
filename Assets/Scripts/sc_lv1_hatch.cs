using UnityEngine;

public class sc_lv1_hatch : Interactable
{


    public override void Interact()
    {
        base.Interact();


    }

    public void pickup()
    {
        this.GetComponent<Animator>().SetBool("is_open", true);
    }
}
