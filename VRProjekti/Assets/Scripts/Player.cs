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
    private float movementSpeed = 1f;


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
        lift = GameObject.FindGameObjectWithTag("Lift").GetComponent<Lift>();
    }

    void Update()
    {

        // Lift
        // ====

        float raiseValue = raiseLiftReference.action.ReadValue<float>();
        float lowerValue = lowerLiftReference.action.ReadValue<float>();

        if (raiseValue != 0)
        {
            lift.RaiseLift(raiseValue);
        }

        if (lowerValue != 0)
        {
            lift.LowerLift(lowerValue);
        }

        // Movement
        // ========

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * movementSpeed * Time.deltaTime);
        }
    }

    void SpawnCube(InputAction.CallbackContext context)
    {
        cubeSpawner.SpawnCube();
    }
}
