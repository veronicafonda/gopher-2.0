using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_deathwall : MonoBehaviour
{
    public GameObject spawn1, spawn2, spawn3, spawn4, spawn5;
    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("mmbgm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("death");
        GameObject butterfly = other.gameObject;
        GameObject butterflyRes;

        if (butterfly.name == "Butt1")
        {
            butterflyRes = Instantiate(butterfly, spawn1.transform.position, spawn1.transform.rotation, spawn1.transform);
            butterflyRes.name = "Butt1(Clone)";
        }
        else if (butterfly.name == "Butt1(Clone)")
        {
            butterflyRes = Instantiate(butterfly, spawn1.transform.position, spawn1.transform.rotation, spawn1.transform);
            butterflyRes.name = "Butt1";
        }

        else if (butterfly.name == "Butt2")
        {
            butterflyRes = Instantiate(butterfly, spawn2.transform.position, spawn2.transform.rotation, spawn2.transform);
            butterflyRes.name = "Butt2(Clone)";
        }
        else if (butterfly.name == "Butt2(Clone)")
        {
            butterflyRes = Instantiate(butterfly, spawn2.transform.position, spawn2.transform.rotation, spawn2.transform);
            butterflyRes.name = "Butt2";
        }

        else if (butterfly.name == "Butt3")
        {
            butterflyRes = Instantiate(butterfly, spawn3.transform.position, spawn3.transform.rotation, spawn3.transform);
            butterflyRes.name = "Butt3(Clone)";
        }
        else if (butterfly.name == "Butt3(Clone)")
        {
            butterflyRes = Instantiate(butterfly, spawn3.transform.position, spawn3.transform.rotation, spawn3.transform);
            butterflyRes.name = "Butt3";
        }

        else if (butterfly.name == "Butt4")
        {
            butterflyRes = Instantiate(butterfly, spawn4.transform.position, spawn4.transform.rotation, spawn4.transform);
            butterflyRes.name = "Butt4(Clone)";
        }
        else if (butterfly.name == "Butt4(Clone)")
        {
            butterflyRes = Instantiate(butterfly, spawn4.transform.position, spawn4.transform.rotation, spawn4.transform);
            butterflyRes.name = "Butt4";
        }

        else if (butterfly.name == "Butt5")
        {
            butterflyRes = Instantiate(butterfly, spawn5.transform.position, spawn5.transform.rotation, spawn5.transform);
            butterflyRes.name = "Butt5(Clone)";
        }
        else if (butterfly.name == "Butt5(Clone)")
        {
            butterflyRes = Instantiate(butterfly, spawn5.transform.position, spawn5.transform.rotation, spawn5.transform);
            butterflyRes.name = "Butt5";
        }
        Destroy(other.gameObject);
        
    }
}
