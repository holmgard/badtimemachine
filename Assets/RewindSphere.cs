using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSphere : MonoBehaviour
{
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0F); // TODO layermask cubes for performance (different overload)

        foreach (var collider in colliders)
        {
            BadTimeMachine badTimeMachine = collider.gameObject.GetComponent<BadTimeMachine>();
            if(badTimeMachine != null)
            {
                Debug.Log("Rewinding");
                badTimeMachine.RewindFixedTimeFrame();
            }
        }
    }
}
