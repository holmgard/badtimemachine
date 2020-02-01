using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToRewindableRepulsion : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public RewindablesManager rewindablesManager;
    public int playerNumber;
    
    private void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerNumber = GetComponent<Controller>().playerNumber;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<BTMProjectile>() != null)
        {
            Vector3 averageContact = collision.gameObject.transform.position;

            Vector3 repulsiveForce = transform.position - averageContact;
            repulsiveForce.y = 0.0F;
            float collisionSpeed = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude + 5F;
            playerRigidbody.constraints |= RigidbodyConstraints.FreezeRotationY;

            float repulsionModifier = (1 - ScoreManager.Instance.GetPlayerScore(playerNumber)) * 2f;

            playerRigidbody.AddForce(repulsiveForce * collisionSpeed * repulsionModifier, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-repulsiveForce * collisionSpeed);
            playerRigidbody.constraints &= ~(RigidbodyConstraints.FreezeRotationY);
        }
    }

    private void OnCollisionEnter(Collision collision)
        {
        if (rewindablesManager.IsRewindable(collision.gameObject.GetInstanceID()))
        {
            Vector3 averageContact = Vector3.zero;
            foreach (var contact in collision.contacts)
            {
                averageContact += contact.point;
            }
            averageContact /= collision.contactCount;

            Vector3 repulsiveForce = transform.position - averageContact;
            repulsiveForce.y = 0.0F;
            float collisionSpeed = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude + 5F;
            playerRigidbody.constraints |= RigidbodyConstraints.FreezeRotationY;

            float repulsionModifier = (1 - ScoreManager.Instance.GetPlayerScore(playerNumber)) * 4F;
            
            playerRigidbody.AddForce(repulsiveForce * collisionSpeed * repulsionModifier, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-repulsiveForce * collisionSpeed);
            playerRigidbody.constraints &= ~(RigidbodyConstraints.FreezeRotationY);
        }
    }
}
