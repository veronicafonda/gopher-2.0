using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade_effect : MonoBehaviour
{
    public Image black_panel;

    // Start is called before the first frame update
    void Start()
    {
        black_panel.canvasRenderer.SetAlpha(1f);
        fade_out();
    }

    // Update is called once per frame
    void fade_in()
    {
        black_panel.CrossFadeAlpha(1, 1, false);
    }

    void fade_out()
    {
        black_panel.CrossFadeAlpha(0, 1, false);
    }
}
