using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChange : MonoBehaviour
{

    public InputActionReference colorReference = null;
    private MeshRenderer mRenderer = null;
    private float lastValue = 0f;

    void Awake()
    {
        mRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float value = colorReference.action.ReadValue<float>();

        if (value != lastValue)
        {
            UpdateColor(value);
            lastValue = value;
        }
    }

    void UpdateColor(float newValue)
    {
        mRenderer.material.color = new Color(newValue, newValue, 0);
    }
}
