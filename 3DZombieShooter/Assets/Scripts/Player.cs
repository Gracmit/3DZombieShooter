using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2;
    [SerializeField] private float _rotationSpeed = 2;
    
    private CharacterController _controller;
    private Camera _camera;

    private void Awake()
    { 
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        var rotationX = new Vector3(- 1 * Input.GetAxis("Mouse Y") * _rotationSpeed, 0, 0);
        var rotationY = new Vector3(0, Input.GetAxis("Mouse X") * _rotationSpeed, 0 );
        
        transform.Rotate(rotationY);
        _camera.transform.Rotate(rotationX);

        Vector3 movementInput = new Vector3(horizontal, 0 ,vertical);
        Vector3 movement = transform.rotation * movementInput * _movementSpeed;
        _controller.SimpleMove(movement);
    }
}
