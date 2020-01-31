using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public struct TimeStep
{
    public Vector3 position;
    public Quaternion rotation;
    public float drag;
    public float angDrag;
    public Vector3 velocity;
    public Vector3 angVelocity;
    
    public TimeStep(Vector3 position, Quaternion rotation, float drag, float angDrag, Vector3 velocity, Vector3 angVelocity)
    {
        this.position = position;
        this.rotation = rotation;
        this.drag = drag;
        this.angDrag = angDrag;
        this.velocity = velocity;
        this.angVelocity = angVelocity;
    }
}

public class BadTimeMachine : MonoBehaviour
{
    public bool forwardsInTime;
    public bool backwardsInTime;

    public List<TimeStep> timeLine;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLine = new List<TimeStep>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            forwardsInTime = false;
            backwardsInTime = true;
            //Debug.Log("Backwards in time!");
        }
        else
        {
            forwardsInTime = true;
            backwardsInTime = false;
        }
    }

    void FixedUpdate()
    {
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        
        if (forwardsInTime)
        {
            timeLine.Add((new TimeStep(
                transform.position, 
                transform.rotation,
                myRigidbody.drag,
                myRigidbody.angularDrag,
                myRigidbody.velocity,
                myRigidbody.angularVelocity
            )));
        } else if (backwardsInTime && timeLine.Count > 0)
        {
            var lastStep = timeLine[timeLine.Count - 1];
            transform.position = lastStep.position;
            transform.rotation = lastStep.rotation;
            myRigidbody.drag = lastStep.drag;
            myRigidbody.angularDrag = lastStep.angDrag;
            myRigidbody.velocity = lastStep.velocity;
            myRigidbody.angularVelocity = lastStep.angVelocity;
            timeLine.RemoveAt(timeLine.Count-1);
        }
    }
}
