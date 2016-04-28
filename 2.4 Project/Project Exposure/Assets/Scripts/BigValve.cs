﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigValve : MonoBehaviour {

    public GameObject line1Path;
    public GameObject line2Path;

    RaycastHit hit;
    private Transform valve;
    public Transform rayPointer;
    public int currentState = 0;
    bool InRange = false;
    public int valveID;
    bool inRotation = false;
    Quaternion targetRotation;
    ValveLineJoint[] line1;
    ValveLineJoint[] line2;
    public ParticleSystem smoke1;
    public ParticleSystem smoke2;
    void Awake()
    {

      
    }
    // Use this for initialization
    void Start () {

        valve = transform.GetChild(0);
        ConnectSmallValves();
        SetupPipeConnection();
        DisableLine(1);
        DisableLine(2);

    }
    void SetupPipeConnection()
    {
        line1 = line1Path.GetComponentsInChildren<ValveLineJoint>();
        int line1Lenght = line1.Length;
        for (int i = 0; i < line1Lenght; i++)
        {
           // print("name order -> " + line1[i].gameObject.name);
            if(line1[i] != line1[line1Lenght - 1])
            {
              //  Debug.Log("set " + line1[i].name + " to " + line1[i + 1].name);
                line1[i].connectTo = line1[i + 1];
            }
            
        }

        line2 = line2Path.GetComponentsInChildren<ValveLineJoint>();
        int line2Lenght = line2.Length;
        for (int i = 0; i < line2Lenght; i++)
        {
            print("name order -> " + line1[i].gameObject.name);
            if (line2[i] != line2[line2Lenght - 1])
            {
                Debug.Log("set " + line1[i].name + " to " + line1[i + 1].name);
                line2[i].connectTo = line2[i + 1];
            }

        }
    }
    void ConnectSmallValves()
    {
        PipeScript[] pipes = FindObjectsOfType<PipeScript>();
        for (int i = 0; i < pipes.Length; i++)
        {
            if(pipes[i].valveID == valveID)
            {
                pipes[i].controlValve = this;
            }
        }        
    }
    void FixedUpdate()
    {
        //if (inRotation)
        //{

        //    valve.transform.rotation = Quaternion.Slerp(valve.transform.rotation, targetRotation, Time.deltaTime);
        //    while (valve.transform.rotation != targetRotation)
        //    {
                
        //    }
        //    //inRotation = false;
        //}

    }

    void OnMouseDown()
    {
        if (InRange)
            Rotate();
    }
    void ActivateLine(int index)
    {
        switch(index)
        {
            case 1:

                //float distance = Vector3.Distance(transform.position, line1[0].transform.position);
                //Vector3 direction = (line1[0].transform.position - transform.position);
                //direction.Normalize();

                //Debug.DrawRay(transform.position, direction * distance, Color.green, 1000);
                smoke1.Play();
                for (int i = 0; i < line1.Length; i++)
                {
                    line1[i].DrawConnection(Color.green);
                }

                break;
            case 2:

                //float distance2 = Vector3.Distance(transform.position, line2[0].transform.position);
                //Vector3 direction2 = (line2[0].transform.position - transform.position);
                //direction2.Normalize();

                //Debug.DrawRay(transform.position, direction2 * distance2, Color.green, 1000);
                smoke2.Play();
                for (int i = 0; i < line1.Length; i++)
                {
                    line2[i].DrawConnection(Color.green);
                }

                break;
        }
    }
  
    void DisableLine(int index)
    {
        switch (index)
        {
            case 1:
                //float distance = Vector3.Distance(transform.position, line1[0].transform.position);
                //Vector3 direction = (line1[0].transform.position - transform.position);
                //direction.Normalize();

                //Debug.DrawRay(transform.position, direction * distance, Color.red, 1000);
                smoke1.Stop();

                for (int i = 0; i < line1.Length; i++)
                {
                    line1[i].DeleteConnection();
                }
                break;
            case 2:
                smoke2.Stop();
                //float distance2 = Vector3.Distance(transform.position, line2[0].transform.position);
                //Vector3 direction2 = (line2[0].transform.position - transform.position);
                //direction2.Normalize();

                //Debug.DrawRay(transform.position, direction2 * distance2, Color.red, 1000);
                for (int i = 0; i < line2.Length; i++)
                {
                    line2[i].DeleteConnection();
                }
                break;
        }
    }
    void Rotate()
    {
        // targetRotation = Quaternion.Euler(0, 90, 0) * valve.transform.rotation;
        // inRotation = true;
        valve.transform.Rotate(new Vector3(0, 90, 0));
        if(Physics.Raycast(rayPointer.transform.position,rayPointer.transform.forward,out hit,1f))
        {
            switch(hit.transform.name)
            {
                case "Input":
                    currentState = 3;
                    DisableLine(2);
                    break;

                case "Line1":
                    currentState = 1;
                    ActivateLine(1);
                    break;

                case "Line2":
                    currentState = 2;
                    ActivateLine(2);
                    break;

                case "Off":
                    currentState = 0;
                    DisableLine(1);
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;
        }
    }
}
