using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] private Transform hand;
    public InputActionReference rotationReference = null;

    public bool followHand = false;


    void Update()
    {
        if (followHand)
        {
            transform.LookAt(hand.position);

            transform.localRotation = Quaternion.Euler(
                transform.localRotation.eulerAngles.x,
                transform.localRotation.eulerAngles.y,
                0f
            );
        }
    }

    public Vector3 GetRotations()
    {
        return new Vector3(
            transform.localRotation.eulerAngles.x,
            transform.localRotation.eulerAngles.y,
            transform.localRotation.eulerAngles.z
        );
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("VRController"))
        {
            followHand = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("VRController"))
        {
            followHand = false;
        }
    }
}
