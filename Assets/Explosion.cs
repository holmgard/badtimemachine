using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Transform explosionSource;
    public Rigidbody myRigidbody;
    public float explosionForce = 1000f;
    public float explosionRadius = 500f;
    public float upwardsModifier = 5f;
    
    void Start()
    {
        explosionSource = transform;
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Explode()
    {
        myRigidbody.AddExplosionForce(explosionForce, explosionSource.position, explosionRadius, upwardsModifier);
        AudioManager.Instance.SoundEffect(AudioManager.SoundEffects.BlocksForward);
    }

    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
                //Debug.Log("Exploding!");
                Explode();
        }
    }*/
}
