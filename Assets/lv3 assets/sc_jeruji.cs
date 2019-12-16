using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_jeruji : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().SetBool("is_open", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
