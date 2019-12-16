using UnityEngine;

public class sc_lv1_lemari : Interactable
{
    private bool stat = true;

    public override void Interact()
    {
        base.Interact();
        this.GetComponent<Animator>().SetBool("is_open", stat);
        this.GetComponent<Animator>().SetFloat("direction", 1);

    }
}
