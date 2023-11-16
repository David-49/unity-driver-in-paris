using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody RB;
    public GameObject CarBody;

    public Transform Wheel1;
    public Transform Wheel2;
    public Transform Wheel3;
    public Transform Wheel4;

    public Transform Right;
    public Transform Left;
    public Transform Straight;

    public TrailRenderer Trail1;
    public TrailRenderer Trail2;
    public TrailRenderer Trail3;
    public TrailRenderer Trail4;
    public float speedForward = 150;
    public float speedReverse = 80;
    public float rotationSpeed = 120;

    public AudioSource CarEngine;
    public AudioSource CarDrift;
    public bool DriftCheck;
    private bool hasStartedMoving = false;

    private void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        RB.useGravity = true; // Add this line to enable gravity
        RB.angularDrag = 5f; // Added angular drag for smoother rotation
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            RB.AddForce(transform.forward * speedForward * verticalInput);
            UpdateWheelsRotation(horizontalInput);

            if (!hasStartedMoving)
            {
                print("Car has started moving");
                CarEngine.Play();
                hasStartedMoving = true;
            }
        }
        else if (verticalInput < 0)
        {
            RB.AddForce(transform.forward * speedReverse * verticalInput);
            UpdateWheelsRotation(-horizontalInput); // Reverse wheel rotation for reverse movement
        }
        else
        {
            CarEngine.Stop();
            hasStartedMoving = false; // Reset the flag when the car stops moving
        }

        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);

        if (!Input.GetKey("d") && !Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("s"))
        {
            RB.velocity *= 0.95f; // Damping to slow down when not pressing any keys
        }

        UpdateTrailEmittance();
    }

    private void UpdateWheelsRotation(float rotationAmount)
    {
        Wheel1.localRotation = Quaternion.Euler(-500 * rotationAmount, 0, 0);
        Wheel2.localRotation = Quaternion.Euler(-500 * rotationAmount, 0, 0);
        Wheel3.localRotation = Quaternion.Euler(500 * rotationAmount, 0, 0);
        Wheel4.localRotation = Quaternion.Euler(500 * rotationAmount, 0, 0);
    }

    private void UpdateTrailEmittance()
    {
        float rotationY = CarBody.transform.localRotation.eulerAngles.y;

        if (Mathf.Abs(rotationY) > 15 && Mathf.Abs(rotationY) < 345)
        {
            Trail1.emitting = true;
            Trail2.emitting = true;
            Trail3.emitting = true;
            Trail4.emitting = true;

            if (!DriftCheck)
            {
                DriftCheck = true;
                CarDrift.Play();
            }
        }
        else
        {
            DriftCheck = false;

            Trail1.emitting = false;
            Trail2.emitting = false;
            Trail3.emitting = false;
            Trail4.emitting = false;
        }
    }
}
