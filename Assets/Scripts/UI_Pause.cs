using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    public Animator pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPause()
    {
        if(pauseUI.GetBool("PauseOpen") == false)
        {
            pauseUI.SetBool("PauseOpen", true);
        }
        else
        {
            pauseUI.SetBool("PauseOpen", false);
            Time.timeScale = 1;
        }
        
    }
}
