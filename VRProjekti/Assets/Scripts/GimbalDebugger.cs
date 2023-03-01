using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimbalDebugger : MonoBehaviour
{
    [SerializeField] private Transform MMU;


    void Update()
    {
        transform.position = MMU.position + MMU.forward;
        transform.rotation = MMU.rotation;
    }
}
