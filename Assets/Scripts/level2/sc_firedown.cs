using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_firedown : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("fire");
        ps = GetComponent<ParticleSystem>();
    }

    public void reduce1()
    {
        var main = ps.main;
        main.startSpeed = .4f;
    }

    public void reduce2()
    {
        var main = ps.main;
        var main2 = ps.emission;
        main.startSpeed = .3f;
        main2.rateOverTime = 10;
    }

    public void reduce3()
    {
        Destroy(this.gameObject);
    }
}
