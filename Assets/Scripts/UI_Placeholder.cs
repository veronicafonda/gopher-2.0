﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Placeholder : MonoBehaviour
{

    public Image DialogBox;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        DialogBox.transform.position = namePos;
    }
}
