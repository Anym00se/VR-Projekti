using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public List<GameObject> stackCubes;
    private Transform tehLine;
    private float tehLineRaiseSpeed = 0.01f;
    private float reachTehLineTimerDefault = 10f;
    private float reachTehLineTimer;
    private Image warningImage;
    private bool gameEnded = false;

    // For anyone reading this:
    // "Teh Line" means "the line" but is a reference to Mubbly Tower.


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
        reachTehLineTimer = reachTehLineTimerDefault;
        warningImage = GameObject.FindGameObjectWithTag("WarningImage").GetComponent<Image>();
    }

    void Update()
    {
        // Case: Game End
        if (reachTehLineTimer <= 0)
        {
            reachTehLineTimer = 0f;

            if (!gameEnded)
            {
                GameEnd();
            }
        }
        // Case: Game Ongoing
        else
        {
            // Raise Teh Line if reached
            if (IsTehLineReached())
            {
                tehLine.position += Vector3.up * tehLineRaiseSpeed * Time.deltaTime;
                reachTehLineTimer = reachTehLineTimerDefault;
            }
            // Reduce timer if Teh Line not reached
            else
            {
                reachTehLineTimer -= Time.deltaTime;
            }

            UpdateWarningFillAmount();
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
        return cube.GetComponent<StackCube>().isBeingGrabbed;
    }

    void GameEnd()
    {
        gameEnded = true;
        Debug.Log("Teh Line not reached in time.\nGame ended.");
    }

    void UpdateWarningFillAmount()
    {
        warningImage.fillAmount = 1 - (reachTehLineTimer / reachTehLineTimerDefault);
    }
}
