﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sc_hero : MonoBehaviour
{
    float speed = 6f;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("we hit " + hit.collider.name + " " + hit.point);
                this.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                //move
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 targetDirection = new Vector3(h, 0f, v);
        targetDirection =
        Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        if (h != 0f || v != 0)
        {
            this.GetComponent<Animator>().SetBool("is_walk", true);
            Quaternion targetRotation =
            Quaternion.LookRotation(targetDirection, Vector3.up);
            this.transform.rotation = targetRotation;
            this.transform.position +=
            Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * v * speed
            * Time.deltaTime;
            this.transform.position +=
            Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * h * speed *
            Time.deltaTime;
        }
        else
        {
            this.GetComponent<Animator>().SetBool("is_walk", false);
        }
    }
}
