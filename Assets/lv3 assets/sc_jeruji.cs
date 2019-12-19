using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_jeruji : MonoBehaviour
{
    public void jeruji_open()
    {
        this.GetComponent<Animator>().SetBool("is_open", true);
    }
}
