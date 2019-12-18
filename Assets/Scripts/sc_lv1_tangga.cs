using UnityEngine;

public class sc_lv1_tangga : Interactable
{
    private bool stat = true;

    public override void Interact()
    {
        base.Interact();       

    }

    public void pickup()
    {
        //this.GetComponent<Animator>().SetBool("is_move", stat);
    }
}
