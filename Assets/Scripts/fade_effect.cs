using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade_effect : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start() { 
        this.GetComponent<Animator>().SetBool("is_fade", false);

    }

}
