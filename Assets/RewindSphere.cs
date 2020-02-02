using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSphere : MonoBehaviour
{
    private RewindablesManager rewindablesManager;
    public float sphereRadius = 5.0F;

    private bool rewinding = false;
    HashSet<int> rewindAffectedCubes = new HashSet<int>();

    [Header("Debug controls")]
    public bool debugSphere = true;

    int playerNumber;

    private void Update()
    {
        if (Input.GetButtonDown($"Rewind{playerNumber}"))
        {
            rewinding = true;
            AudioManager.Instance.SoundEffect(AudioManager.SoundEffects.BlocksBackward);
        }
        else if (Input.GetButtonUp($"Rewind{playerNumber}"))
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
        playerNumber = gameObject.GetComponent<Controller>().playerNumber;
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
        if (debugSphere) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, sphereRadius);
        }
    }
}
