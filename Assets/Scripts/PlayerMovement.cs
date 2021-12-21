using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Car settings")]
    [SerializeField] float steeringFactor;
    [SerializeField] float engineFactor;
    [SerializeField] [Range(0, 1)] float driftFactor;

    // Local variables
    float steeringInput;
    float engineInput;
    float rotationAngle;

    // Components
    Rigidbody2D rb;
    PlayerInputActions controls;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerInputActions();
        controls.Player.Enable();
    }

    private void Update()
    {
        SetInputVector();

    }
    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
        KillOrthogonalVelocity();
    }

    private void ApplySteering()
    {
        // Update the rotation based on the input
        rotationAngle -= steeringInput * steeringFactor;

        // Apply steering by rotating the car object
        rb.MoveRotation(rotationAngle);
    }

    private void ApplyEngineForce()
    {
        // Create a force for the engine
        Vector2 engineForceVector = transform.up * engineInput * engineFactor;

        // Apply force and pushes the car forward
        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void SetInputVector()
    {
        steeringInput = controls.Player.Movement.ReadValue<Vector2>().x;
        engineInput = controls.Player.engine.ReadValue<float>() - controls.Player.brake.ReadValue<float>();
    }


    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

}
