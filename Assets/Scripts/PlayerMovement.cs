using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        steeringInput = Input.GetAxis("Horizontal");
        engineInput = Input.GetAxis("Vertical");
    }


    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

}
