using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference spawnCubeReference = null;
    public InputActionReference raiseLiftReference = null;
    public InputActionReference lowerLiftReference = null;
    private CubeHolder cubeSpawner;
    private Lift lift;


    void Awake()
    {
        spawnCubeReference.action.started += SpawnCube;
        raiseLiftReference.action.started += RaiseLift;
        lowerLiftReference.action.started += LowerLift;
    }

    void OnDestroy()
    {
        spawnCubeReference.action.started -= SpawnCube;
        raiseLiftReference.action.started -= RaiseLift;
        lowerLiftReference.action.started -= LowerLift;
    }

    void Start()
    {
        cubeSpawner = GameObject.FindGameObjectWithTag("CubeHolder").GetComponent<CubeHolder>();
        lift = GameObject.FindGameObjectWithTag("Lift").GetComponent<Lift>();
    }

    void SpawnCube(InputAction.CallbackContext context)
    {
        cubeSpawner.SpawnCube();
    }

    void RaiseLift(InputAction.CallbackContext context)
    {
        lift.RaiseLift();
    }

    void LowerLift(InputAction.CallbackContext context)
    {
        lift.LowerLift();
    }
}
