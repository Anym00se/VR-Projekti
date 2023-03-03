using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public List<GameObject> stackCubes;
    private Transform tehLine;
    private float tehLineRaiseSpeed = 0.0001f; 


    private void Awake()
    {
        // Assign the global GameManager.instance object
        if (instance == null)
        {
            instance = this;
            stackCubes = new List<GameObject>();
        }
        else
        {
            // Prevent duplicates in the scene
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tehLine = GameObject.FindGameObjectWithTag("TehLine").transform;
    }

    void Update()
    {
        if (IsTehLineReached())
        {
            tehLine.position += Vector3.up * tehLineRaiseSpeed;
            Debug.Log("Raising Teh Line!");
        }
        else
        {
            Debug.Log("Teh Line not reached!");
        }
    }

    bool IsTehLineReached()
    {
        bool lineReached = false;

        foreach(GameObject cube in stackCubes)
        {
            if (
                cube.transform.position.y >= tehLine.transform.position.y - 0.15f &&
                IsCubeInCorrectArea(cube.transform.position) &&
                !IsCubeBeingInteracted(cube)
            )
            {
                lineReached = true;
                break;
            }
        }

        return lineReached;
    }

    bool IsCubeInCorrectArea(Vector3 cubePosition)
    {
        bool isInRightPosition = false;
        float bounds = 0.55f;

        if (
            cubePosition.x >= -bounds && cubePosition.x <= bounds && 
            cubePosition.z >= -bounds && cubePosition.z <= bounds
        )
        {
            isInRightPosition = true;
        }

        return isInRightPosition;
    }

    bool IsCubeBeingInteracted(GameObject cube)
    {
        return false;
    }
}
