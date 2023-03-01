using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] private bool isRight = false; // true = is right joystic, false = is left joystick
    [SerializeField] private Transform hand;
    [SerializeField] private Transform knob;
    [SerializeField] private Transform MMU;

    public bool followHand = false;


    void Update()
    {
        if (followHand)
        {
            transform.LookAt(hand.transform.position, transform.up);
        }
    }

    public Vector2 GetJoystickInput()
    {
        float inputForward = Vector3.Project(
            knob.position - transform.position,
            MMU.forward
        ).x * 10f;
        float inputRight = Vector3.Project(
            knob.position - transform.position,
            MMU.right
        ).z * -10f;

        if (followHand)
        {
            return new Vector2(inputForward, inputRight);
        }
        else
        {
            return Vector2.zero;
        }
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

            // Reset the rotation
            transform.localRotation = Quaternion.identity;
        }
    }
}
