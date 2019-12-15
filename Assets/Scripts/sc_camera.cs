using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_camera : MonoBehaviour
{
    public GameObject pause_helper;

    // Start is called before the first frame update
    void Start()
    {
        pause_helper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_Pause.pauseBool)
        {
            pause_helper.SetActive(true);
        }
        else
        {
            pause_helper.SetActive(false);
        }
    }
}
