using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSphere : MonoBehaviour
{
    public RewindablesManager rewindablesManager;

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0F, 0x0100); // 0x0100 Stands for layer 8

        foreach (var collider in colliders)
        {
            int temp = collider.gameObject.GetInstanceID();
            BadTimeMachine badTimeMachine = rewindablesManager.GetBadTimeMachine(temp);
            badTimeMachine.RewindFixedTimeFrame();
        }
    }
}
