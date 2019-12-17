using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class sc_obj : MonoBehaviour
{
    public Sprite sprite;

    private void Start()
    {
        if(sc_hero.levelProgress == 0)
        {
            sprite = Resources.Load<Sprite>("keranjang_baju_1");
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
            sprite = Resources.Load<Sprite>("keranjang_baju_1");
        }
        else if (sc_hero.levelProgress == 1)
        {
            sprite = Resources.Load<Sprite>("keranjang_baju_2");
        }
        else if (sc_hero.levelProgress == 2)
        {
            sprite = Resources.Load<Sprite>("keranjang_baju_3");
        }
    }
}
