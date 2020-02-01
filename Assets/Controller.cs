using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [Header("Control params")]
    public float speed;
    public float rotSpeed;

    [Header("Player info")]
    public int playerNumber;
    public Color playerColor;

    private Rigidbody _body;
    private Renderer _renderer;

    void Awake() {
        _body = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.localRotation;

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = playerColor;
    }

    [Header("Debug")]
    public Vector3 velocity;
    public float cameraX;
    public Quaternion rotation;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis($"Horizontal{playerNumber}") * speed;
        float y = Input.GetAxis($"Vertical{playerNumber}") * speed;
        velocity = new Vector3(
            x,
            0,
            y
        ) * speed;

        cameraX = Input.GetAxis($"CameraHor{playerNumber}");
        // if (Mathf.Abs(cameraIn) > 0.11)
        {
            rotation = Quaternion.Euler(0, cameraX * rotSpeed, 0);
            _body.rotation *= rotation;
        }
            
        velocity = _body.rotation * velocity;
        velocity.y = _body.velocity.y;

        _body.velocity = velocity;
        
    }
}
