﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_tutup_besi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Animator>().SetBool("is_open", true);
    }
}
