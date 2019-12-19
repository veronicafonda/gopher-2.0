using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_cacing : MonoBehaviour
{
    public void show()
    {
        this.GetComponent<Animator>().SetBool("is_show", true);
    }

    public void hide()
    {
        this.GetComponent<Animator>().SetBool("is_show", false);
    }

    public void empty(bool x)
    {
        this.GetComponent<Animator>().SetBool("empty", x);
    }


}
