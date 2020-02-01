using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BadTimeMachine))]
[RequireComponent(typeof(Rigidbody))]
public class BTMProjectile : MonoBehaviour
{
    [Header("Config")]
    public float speed;
    public float radius;
    public float lifespan;

    [Header("Runtime info")]
    public Vector3 direction;
    public float lifetime;

    private BadTimeMachine _btm;
    private Rigidbody _body;

    public void Spawn(Vector3 pos, Vector3 dir, bool forward) {
        _btm = GetComponent<BadTimeMachine>();
        _body = GetComponent<Rigidbody>();

        direction = dir.normalized;

        transform.position = pos;

        //_btm.forwardsInTime = forward;
        //_btm.backwardsInTime = !forward;
        _body.velocity = dir * speed;

        lifetime = lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
            Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Explosion explosion = other.gameObject.GetComponent<Explosion>();
        if(explosion != null)
        {
            explosion.Explode();
        }
    }
}
