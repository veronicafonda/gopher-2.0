using UnityEngine;

public class int_lv1_wardrobe : Interactable
{
    private bool stat = true;

    public override void Interact()
    {
        base.Interact();
        this.GetComponent<Animator>().SetBool("is_open", stat);
        this.GetComponent<Animator>().SetFloat("direction", 1);

    }

}
