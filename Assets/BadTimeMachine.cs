using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TimeStep
{
    public Vector3 position;
    public Quaternion rotation;
    
    public TimeStep(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
    }
}

public class BadTimeMachine : MonoBehaviour
{
    public bool forwardsInTime;
    public bool backwardsInTime;

    bool recordCube = true;

    public List<TimeStep> timeLine;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLine = new List<TimeStep>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.R))
        {
            forwardsInTime = false;
            backwardsInTime = true;
            //Debug.Log("Backwards in time!");
        }
        else
        {
            forwardsInTime = true;
            backwardsInTime = false;
        }*/
    }

    void FixedUpdate()
    {
        if (recordCube)
        {
            timeLine.Add((new TimeStep( gameObject.transform.position, gameObject.transform.rotation )));
        }
    }

    public void RewindFixedTimeFrame()
    {
        recordCube = false;
        if (timeLine.Count > 0)
        {
            var lastStep = timeLine[timeLine.Count - 1];
            transform.position = lastStep.position;
            transform.rotation = lastStep.rotation;
            timeLine.RemoveAt(timeLine.Count - 1);
        } 
    }
}
