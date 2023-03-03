using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference spawnCubeReference = null;
    public InputActionReference raiseLiftReference = null;
    public InputActionReference lowerLiftReference = null;
    public InputActionReference moveReference = null;
    private CubeHolder cubeSpawner;
    private Lift lift;
    private float movementSpeed = 1f;
    [SerializeField] private Transform playerDirectionTransform;


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

        playerDirectionTransform.rotation = Quaternion.Euler(
            0f,
            playerDirectionTransform.rotation.eulerAngles.y,
            0f
        );

        // VR input
        Vector2 movementVector = moveReference.action.ReadValue<Vector2>();
        transform.Translate(playerDirectionTransform.forward * movementVector.y * movementSpeed * Time.deltaTime);
        transform.Translate(playerDirectionTransform.right * movementVector.x * movementSpeed * Time.deltaTime);

        // Keyboard input
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(playerDirectionTransform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-playerDirectionTransform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(playerDirectionTransform.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-playerDirectionTransform.right * movementSpeed * Time.deltaTime);
        }
    }

    void SpawnCube(InputAction.CallbackContext context)
    {
        cubeSpawner.SpawnCube();
    }
}
