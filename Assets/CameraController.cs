using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float verticalMovementSpeed;

    public float minDistance;
    public float maxDistance;

    public float minHeight;
    public float maxHeight;

    public float xSwizzling = 1;
    public float swizzlingSpeed = 0.1f;

    public Transform target;

    [Header("Crosshairs")]
    public Sprite crosshairsSprite;
    public int crosshairWidth = 40;
    public int crosshairHeight = 40;
    
    [Header("Debug")]
    public float cameraPercPos;

    private Controller _playerController;
    private Camera _camera;
    private int _playerNumber;
    private float _heightExtent;
    private float _distanceExtent;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponentInParent<Controller>();
        _playerNumber = _playerController.playerNumber;

        _camera = GetComponent<Camera>();
        _camera.rect = new Rect (0.5f * (_playerNumber - 1), 0, 0.5f * _playerNumber, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // TMP for testing
        _heightExtent = maxHeight - minHeight;
        _distanceExtent = maxDistance - minDistance;

        cameraPercPos = Mathf.Clamp01(cameraPercPos + Input.GetAxis($"CameraVer{_playerNumber}") * verticalMovementSpeed);
        var camXaxis = Input.GetAxis($"CameraHor{_playerNumber}");

        var newPos = transform.localPosition;
        newPos.x = Mathf.Clamp(newPos.x + swizzlingSpeed * camXaxis, -xSwizzling, xSwizzling);
        newPos.y = Mathf.Lerp(minHeight, maxHeight, cameraPercPos);
        newPos.z = Mathf.Lerp(minDistance, maxDistance, cameraPercPos);

        transform.localPosition = newPos;
        transform.LookAt(target);
    }

    private void OnGUI()
    {
        DrawCrosshair();
    }

    void DrawCrosshair()
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(target.position);
        screenPos.y = Screen.height - screenPos.y;
        GUI.DrawTexture(new Rect(screenPos.x, screenPos.y, crosshairWidth, crosshairHeight), crosshairsSprite.texture);    
    }

    
}
