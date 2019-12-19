using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_firedown : MonoBehaviour
{
    private ParticleSystem ps;

    private void Start()
    {
        this.ps = this.GetComponent<ParticleSystem>();
    }

    public void reduce1()
    {
        //ps.main.startSpeedMultiplier(5f);
    }

    public void reduce2()
    {
        //ps.startSpeed = 0.3f;
        // ps.emissionRate = 10f;
    }
}
