using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] private Transform hand;
    public InputActionReference rotationReference = null;
    public InputActionReference triggerReference = null;


    void Update()
    {
        transform.LookAt(hand.position);

        transform.localRotation = Quaternion.Euler(
            transform.localRotation.eulerAngles.x,
            transform.localRotation.eulerAngles.y,
            // Mathf.Clamp(transform.localRotation.eulerAngles.x, -45f, 45f),
            // Mathf.Clamp(transform.localRotation.eulerAngles.y, -45f, 45f),
            0f
        );
    }

    public Vector3 GetRotations()
    {
        return new Vector3(
            transform.localRotation.eulerAngles.x,
            transform.localRotation.eulerAngles.y,
            transform.localRotation.eulerAngles.z
        );
    }
}
