using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Transform explosionSource;
    
    void Explode()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(5000.0f, explosionSource.position, 500.0f, 5.0f);
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
