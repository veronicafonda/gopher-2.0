using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_lemari : MonoBehaviour
{
    public bool stat = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!stat)
        {
            this.GetComponent<Animator>().SetBool("is_open", true);
            this.GetComponent<Animator>().SetFloat("direction", 1);
            stat = !stat;
        }
        else
        {
            this.GetComponent<Animator>().SetBool("is_open", false);
            this.GetComponent<Animator>().SetFloat("direction", -1);
            stat = !stat;
        }
        
    }
}
