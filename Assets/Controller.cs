﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    [Header("Refs")]
    public GameObject projectilePrefab;
    //public BTMProjectile projectile;
    public Transform cameraTarget;

    private Rigidbody _body;
    private Renderer _renderer;
    private Camera _camera;

    void Awake() {
        _body = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _camera = GetComponentInChildren<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.localRotation;
        _renderer.material.color = playerColor;
    }

    [Header("Debug")]
    public Vector3 velocity;
    public float cameraX;
    public Quaternion rotation;
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown($"Fire{playerNumber}") && !projectile.gameObject.activeInHierarchy) {
        if (Input.GetButtonDown($"Fire{playerNumber}"))
        {
            FireProjectile();
        }

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
        _body.AddForce(velocity);
        if (_body.velocity.magnitude > speed)
        {
            _body.velocity = _body.velocity.normalized * speed;
        }
    }

    void FireProjectile()
    {
        GameObject projectileGO = Instantiate(projectilePrefab);
        BTMProjectile projectile = projectileGO.GetComponent<BTMProjectile>();
        projectile.gameObject.SetActive(true);
        projectile.Spawn(transform.position, cameraTarget.position - _camera.transform.position, true);
    }
}

