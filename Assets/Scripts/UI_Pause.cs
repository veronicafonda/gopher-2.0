using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    public Animator pauseUI;
    public Animator optionUI;
    public static bool pauseBool = false;
    
    // Update is called once per frame
    void Update()
    {

    }

    public void onClickPause()
    {
        if(pauseUI.GetBool("PauseOpen") == false)
        {
            pauseUI.SetBool("PauseOpen", true);
            pauseBool = true;
            //Time.timeScale = 0f;
        }
        else
        {
            pauseUI.SetBool("PauseOpen", false);
            pauseBool = false;
            //Time.timeScale = 1;
        }
        
    }

    public void onClickOptions()
    {
        if (optionUI.GetBool("OptionOpen") == false)
        {
            optionUI.SetBool("OptionOpen", true);
            pauseUI.SetBool("pauseToOption", true);
        }
        else
        {
            optionUI.SetBool("OptionOpen", false);
            pauseUI.SetBool("pauseToOption", false);
        }
    }
    
}
