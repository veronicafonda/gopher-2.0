using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bgm");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
