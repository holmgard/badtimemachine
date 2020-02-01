﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Transform explosionSource;
    public Rigidbody myRigidbody;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Explode()
    {
        myRigidbody.AddExplosionForce(5000.0f, explosionSource.position, 500.0f, 5.0f);
        AudioManager.Instance.SoundEffect(AudioManager.SoundEffects.BlocksForward);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
                //Debug.Log("Exploding!");
                Explode();
        }
    }
}
