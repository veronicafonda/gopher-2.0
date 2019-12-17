using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_walkpointer : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
