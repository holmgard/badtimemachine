using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToRewindableRepulsion : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public RewindablesManager rewindablesManager;

    private void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
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
            playerRigidbody.constraints |= RigidbodyConstraints.FreezeRotationY;
            playerRigidbody.AddForce(repulsiveForce * 10.0F, ForceMode.Impulse);
            playerRigidbody.constraints &= ~(RigidbodyConstraints.FreezeRotationY);
        }
    }
}
