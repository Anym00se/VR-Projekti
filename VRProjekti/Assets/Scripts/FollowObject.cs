using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform obj;


    void Update()
    {
        transform.position = obj.transform.position;
    }
}
