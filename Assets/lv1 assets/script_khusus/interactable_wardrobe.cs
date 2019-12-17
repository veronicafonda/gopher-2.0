using UnityEngine;

public class interactable_wardrobe : Interactable
{
    public GameObject item;

    public override void Interact()
    {
        base.Interact();
        this.GetComponent<Animator>().SetBool("is_walk", false);
    }
}
