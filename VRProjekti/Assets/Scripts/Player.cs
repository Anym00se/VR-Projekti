using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float rcsForce = 10;
    private float rcsTorque = 0.3f;


    void Update()
    {
        bool inputMoveUp = Input.GetKey(KeyCode.LeftShift);
        bool inputMoveDown = Input.GetKey(KeyCode.LeftControl);

        bool inputMoveLeft = Input.GetKey(KeyCode.A);
        bool inputMoveRight = Input.GetKey(KeyCode.D);
        bool inputMoveForward = Input.GetKey(KeyCode.W);
        bool inputMoveBackward = Input.GetKey(KeyCode.S);

        bool inputPitchUp = Input.GetKey(KeyCode.R);
        bool inputPitchDown = Input.GetKey(KeyCode.F);

        bool inputYawLeft = Input.GetKey(KeyCode.Q);
        bool inputYawRight = Input.GetKey(KeyCode.E);

        bool inputRollLeft = Input.GetKey(KeyCode.Z);
        bool inputRollRight = Input.GetKey(KeyCode.C);


        // Translation
        if (inputMoveUp)
        {
            rb.AddForce(transform.up * rcsForce, ForceMode.Force);
        }
        if (inputMoveDown)
        {
            rb.AddForce(transform.up * -rcsForce, ForceMode.Force);
        }
        if (inputMoveLeft)
        {
            rb.AddForce(transform.right * -rcsForce, ForceMode.Force);
        }
        if (inputMoveRight)
        {
            rb.AddForce(transform.right * rcsForce, ForceMode.Force);
        }
        if (inputMoveForward)
        {
            rb.AddForce(transform.forward * rcsForce, ForceMode.Force);
        }
        if (inputMoveBackward)
        {
            rb.AddForce(transform.forward * -rcsForce, ForceMode.Force);
        }

        // Pitch
        if (inputPitchUp)
        {
            rb.AddTorque(transform.right * rcsTorque, ForceMode.Force);
        }
        if (inputPitchDown)
        {
            rb.AddTorque(transform.right * -rcsTorque, ForceMode.Force);
        }

        // Yaw
        if (inputYawLeft)
        {
            rb.AddTorque(transform.up * -rcsTorque, ForceMode.Force);
        }
        if (inputYawRight)
        {
            rb.AddTorque(transform.up * rcsTorque, ForceMode.Force);
        }

        // Roll
        if (inputRollLeft)
        {
            rb.AddTorque(transform.forward * rcsTorque, ForceMode.Force);
        }
        if (inputRollRight)
        {
            rb.AddTorque(transform.forward * -rcsTorque, ForceMode.Force);
        }
    }
}
