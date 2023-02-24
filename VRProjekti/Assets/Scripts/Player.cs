using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float rcsForce = 10;
    private float rcsTorque = 0.3f;

    [SerializeField] private JoystickHandler leftJoyStick;
    [SerializeField] private JoystickHandler rightJoyStick;

     public InputActionReference yawReference = null;
     public InputActionReference upInputReference = null;
     public InputActionReference downInputReference = null;


    void Update()
    {
        // ApplyKeyboardInput();

        // VR input
        // ========

        Vector3 leftJoystickRotations = leftJoyStick.GetRotations();
        Vector3 rightJoystickRotations = rightJoyStick.GetRotations();

        Vector3 leftJoystickRotationsNormalized = new Vector3(
            leftJoystickRotations.x / 90f,
            leftJoystickRotations.y / 90f,
            leftJoystickRotations.z / 90f
        );
        Vector3 rightJoystickRotationsNormalized = new Vector3(
            rightJoystickRotations.x / 90f,
            rightJoystickRotations.y / 90f,
            rightJoystickRotations.z / 90f
        ); 

        // Translation
        rb.AddForce(transform.forward * rcsForce * rightJoystickRotationsNormalized.x, ForceMode.Force);
        rb.AddForce(transform.right * rcsForce * rightJoystickRotationsNormalized.z, ForceMode.Force);

        float up = upInputReference.action.ReadValue<float>();
        float down = downInputReference.action.ReadValue<float>();
        rb.AddForce(transform.up * rcsForce * (up - down), ForceMode.Force);

        // Rotation
        rb.AddTorque(transform.right * rcsTorque * leftJoystickRotationsNormalized.x, ForceMode.Force);
        rb.AddTorque(transform.forward * rcsTorque * leftJoystickRotationsNormalized.z, ForceMode.Force);

        float yaw = yawReference.action.ReadValue<float>();
        rb.AddTorque(transform.up * rcsTorque * yaw, ForceMode.Force);
    }

    private void ApplyKeyboardInput()
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
