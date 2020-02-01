using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float verticalMovementSpeed;

    public float minDistance;
    public float maxDistance;

    public float lowerBound;
    public float upperBound;

    public Transform target;

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
        _camera.rect = new Rect {
            xMin = (_playerNumber - 1)  / 2,
            xMax = (_playerNumber - 1)  / 2 + 0.5f,
            yMin = 0,
            yMax = 1
        };
    }

    // Update is called once per frame
    void Update()
    {
        // TMP for testing
        _heightExtent = upperBound - lowerBound;
        _distanceExtent = maxDistance - minDistance;

        cameraPercPos = Mathf.Clamp01(cameraPercPos + Input.GetAxis($"CameraVer{_playerNumber}") * verticalMovementSpeed);

        var newPos = transform.localPosition;
        newPos.y = Mathf.Lerp(lowerBound, upperBound, cameraPercPos);
        newPos.z = Mathf.Lerp(minDistance, maxDistance, cameraPercPos);

        transform.localPosition = newPos;
        transform.LookAt(target);
    }
}
