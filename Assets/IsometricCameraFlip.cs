using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraFlip : MonoBehaviour
{
    private int cameraPosition = 0;
    
    private Vector3 position0 = new Vector3(23.8f, 33.4f, -25.9f);
    private Quaternion rotation0 = new Quaternion(0.4f, -0.4f, 0.1f, 0.9f);
    private Vector3 position1  = new Vector3(23.8f, 25.8f, 14.28f);
    private Quaternion rotation1  = new Quaternion(0.1f, -0.9f, 0.4f, 0.4f);

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flip();
        }
    }

    public void Flip()
    {
        if (cameraPosition == 0)
        {
            transform.position = position1;
            transform.rotation = rotation1;
            cameraPosition = 1;
        } else if (cameraPosition == 1)
        {
            transform.position = position0;
            transform.rotation = rotation0;
            cameraPosition = 0;
        }
        Debug.Log("Flipped to: " + cameraPosition);
    }
}
