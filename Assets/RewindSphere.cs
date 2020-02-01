using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSphere : MonoBehaviour
{
    private RewindablesManager rewindablesManager;
    public float sphereRadius = 5.0F;

    private bool rewinding = false;
    HashSet<int> rewindAffectedCubes = new HashSet<int>();

    private void Update()
    {
        if (Input.GetButtonDown("Rewind"))
        {
            rewinding = true;
        }
        else if (Input.GetButtonUp("Rewind"))
        {
            rewinding = false;
            foreach (var rewindAffectedCube in rewindAffectedCubes)
            {
                rewindablesManager.GetBadTimeMachine(rewindAffectedCube).StartRecording();
            }
            rewindAffectedCubes.Clear();
        }
    }

    void Start() {
        rewindablesManager = RewindablesManager.Instance;
    }
    void FixedUpdate()
    {
        if (rewinding)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius, 0x0100); // 0x0100 Stands for layer 8

            foreach (var collider in colliders)
            {
                int id = collider.gameObject.GetInstanceID();
                if (!rewindAffectedCubes.Contains(id))
                {
                    rewindAffectedCubes.Add(id);
                }
                BadTimeMachine badTimeMachine = rewindablesManager.GetBadTimeMachine(id);
                badTimeMachine.StopRecording();
                badTimeMachine.RewindFixedTimeFrame();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
