using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] private bool isRight = false; // true = is right joystic, false = is left joystick
    [SerializeField] private Transform hand;
    public InputActionReference rotationReference = null;

    public bool followHand = false;

    [SerializeField] private Transform pitchTr;
    [SerializeField] private Transform rollTr;


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
            hand.position - transform.position,
            transform.right
        ).magnitude;
        float inputRight = Vector3.Project(
            hand.position - transform.position,
            transform.up
        ).magnitude;

        // DEBUG
        if (isRight) { Debug.Log("forward :" + inputForward + ", right: " + inputRight); }

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
