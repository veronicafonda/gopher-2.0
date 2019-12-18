using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class sc_obj_level2 : MonoBehaviour
{
    public Sprite sprite;

    private void Start()
    {
        if (sc_hero.levelProgress == 0)
        {
            sprite = Resources.Load<Sprite>("teko");
        }
        else if (sc_hero.levelProgress == 0)
        {

        }
        else if (sc_hero.levelProgress == 0)
        {

        }
    }

    private void Update()
    {
        if (sc_hero.levelProgress == 0)
        {
            sprite = Resources.Load<Sprite>("teko");
        }
        else if (sc_hero.levelProgress == 1)
        {
            sprite = Resources.Load<Sprite>("teko air");
        }
    }
}
