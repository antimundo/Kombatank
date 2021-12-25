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
    float brakeInput;
    float rotationAngle;

    // Components
    Rigidbody2D rb;

    // Input Events
    public void OnSteer(InputAction.CallbackContext ctx) => steeringInput = ctx.ReadValue<Vector2>().x;
    public void OnEngine(InputAction.CallbackContext ctx) => engineInput = ctx.ReadValue<float>();
    public void OnBrake(InputAction.CallbackContext ctx) => brakeInput = ctx.ReadValue<float>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Vector2 engineForceVector = transform.up * (engineInput - brakeInput) * engineFactor;

        // Apply force and pushes the car forward
        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

}
