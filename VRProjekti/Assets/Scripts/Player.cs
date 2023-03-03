using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference spawnCubeReference = null;
    private CubeHolder cubeSpawner;


    void Awake()
    {
        spawnCubeReference.action.started += SpawnCube;
    }

    void OnDestroy()
    {
        spawnCubeReference.action.started -= SpawnCube;
    }

    void Start()
    {
        cubeSpawner = GameObject.FindGameObjectWithTag("CubeHolder").GetComponent<CubeHolder>();
    }

    void SpawnCube(InputAction.CallbackContext context)
    {
        cubeSpawner.SpawnCube();
    }
}
