using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.stackCubes.Add(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.stackCubes.Remove(gameObject);
    }
}
