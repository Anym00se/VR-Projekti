using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleObject : MonoBehaviour
{
    public InputActionReference toggleReference = null;


    void Awake()
    {
        toggleReference.action.started += Toggle;
    }

    void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    void Toggle(InputAction.CallbackContext context)
    {
        bool newActiveState = !gameObject.activeSelf;

        gameObject.SetActive(newActiveState);
    }
}
