using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCube : MonoBehaviour
{
    public bool isBeingGrabbed = false;


    void Start()
    {
        GameManager.instance.stackCubes.Add(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.stackCubes.Remove(gameObject);
    }

    public void SetBeingGrabbed()
    {
        isBeingGrabbed = true;
    }

    public void UnSetBeingGrabbed()
    {
        isBeingGrabbed = false;
    }
}
