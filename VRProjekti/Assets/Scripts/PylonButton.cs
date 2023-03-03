using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonButton : MonoBehaviour
{
    [SerializeField] CubeHolder cubeHolder;
    [SerializeField] Transform button;
    private float buttonPressLength = 0.03f;
    private Vector3 buttonStartPosition;

    void Start()
    {
        buttonStartPosition = button.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("VRController"))
        {
            PressButton();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("VRController"))
        {
            ReleaseButton();
        }
    }

    void PressButton()
    {
        cubeHolder.SpawnCube();

        button.transform.position = buttonStartPosition - Vector3.up * buttonPressLength;
    }

    void ReleaseButton()
    {
        button.transform.position = buttonStartPosition;
    }
}
