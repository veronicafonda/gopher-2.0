using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_camera : MonoBehaviour
{
    public GameObject pause_helper;
    public Vector3 og_pos;
    public Vector3 offset;
    Vector3 velocity;
    Vector3 smoothedPos;
    Vector3 into_pos;
    public float speed;

    public bool is_zoom;


    // Start is called before the first frame update
    void Start()
    {
        is_zoom = false;
        og_pos = this.transform.position;
        pause_helper.SetActive(false);
        smoothedPos = og_pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_Pause.pauseBool)
        {
            pause_helper.SetActive(true);
        }
        else
        {
            pause_helper.SetActive(false);
        }
    }

    private void LateUpdate()
    {

        //Debug.Log("into raw       = " + into.transform.position);
        //into_pos = into.transform.position + offset;
        //Debug.Log("into_pos       = " + into_pos);
        //smoothedPos = Vector3.Lerp(og_pos, into_pos,speed);
        if (is_zoom)
        {
            smoothedPos = Vector3.Slerp(og_pos, into_pos, speed );
            Debug.Log(smoothedPos);
            //smoothedPos = Vector3.SmoothDamp(og_pos, into_pos, ref velocity, speed);
            //Debug.Log("this.transform = " + this.transform.position);
            //Debug.Log("smoothedpos    = " + smoothedPos);
            transform.position = smoothedPos;
        }
        

    }

    public void zooming_in(GameObject into)
    {
        //Debug.Log("into raw       = " + into.transform.position);
        into_pos = into.transform.position + offset;
        //Debug.Log("into_pos       = " + into_pos);
        //smoothedPos = Vector3.Lerp(og_pos, into_pos,speed);
        //smoothedPos = Vector3.SmoothDamp(og_pos, into_pos, ref velocity, speed);
        //Debug.Log("this.transform = " + this.transform.position);
        //Debug.Log("smoothedpos    = " + smoothedPos);
        
        is_zoom = true;
    }
}
