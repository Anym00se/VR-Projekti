using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public List<GameObject> stackCubes;
    private Transform tehLine;
    private float tehLineRaiseSpeed = 0.01f;
    private float reachTehLineTimerDefault = 10f;
    private float reachTehLineTimer;
    private GameObject warningImage;
    private TMP_Text scoreText;
    private Transform timerBar;
    private GameObject gameEndText;
    private bool gameEnded = false;
    public Material validMaterial;
    public Material invalidMaterial;
    public Renderer tehLineRenderer;
    private int score = 0;
    private float tehLineStartHeight;

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
        score = 0;
        tehLine = GameObject.FindGameObjectWithTag("TehLine").transform;
        warningImage = GameObject.FindGameObjectWithTag("WarningImage");
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        timerBar = GameObject.FindGameObjectWithTag("TimerBar").transform;
        gameEndText = GameObject.FindGameObjectWithTag("GameEndText");
        HideGameEndText();
        HideWarning();

        reachTehLineTimer = reachTehLineTimerDefault;
        tehLineStartHeight = tehLine.position.y;
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
                SetValidMaterial();
                HideWarning();
                tehLine.position += Vector3.up * tehLineRaiseSpeed * Time.deltaTime;
                reachTehLineTimer = reachTehLineTimerDefault;

                score = Mathf.FloorToInt((tehLine.position.y - tehLineStartHeight) * 100f);
                scoreText.text = "Score: " + score;
            }
            // Reduce timer if Teh Line not reached
            else
            {
                SetInvalidMaterial();
                ShowWarning();
                reachTehLineTimer -= Time.deltaTime;

                UpdateTimerBarFillAmount();
            }
        }

        // Restart game if pressed "Home"
        if (Input.GetKeyDown(KeyCode.Home))
        {
            RestartGame();
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
        HideWarning();
        ShowGameEndText();
        Debug.Log("Teh Line not reached in time.\nGame ended.");
    }

    void SetValidMaterial()
    {
        tehLineRenderer.material = validMaterial;
    }

    void SetInvalidMaterial()
    {
        tehLineRenderer.material = invalidMaterial;
    }

    void ShowWarning()
    {
        warningImage.SetActive(true);
    }

    void HideWarning()
    {
        warningImage.SetActive(false);
    }

    void UpdateTimerBarFillAmount()
    {
        timerBar.localScale = new Vector3(
            reachTehLineTimer / reachTehLineTimerDefault,
            1f,
            1f
        );
    }

    void ShowGameEndText()
    {
        gameEndText.SetActive(true);
    }

    void HideGameEndText()
    {
        gameEndText.SetActive(false);
    }

    void RestartGame()
    {
        score = 0;
        gameEnded = false;
        tehLine.transform.position = Vector3.up * tehLineStartHeight;
        reachTehLineTimer = reachTehLineTimerDefault;

        // Destroy all StackCubes 
        foreach(GameObject cube in stackCubes)
        {
            Destroy(cube);
        }

        // Spawn one initial StackCube
        GameObject.FindGameObjectWithTag("CubeHolder").GetComponent<CubeHolder>().SpawnCube(true);
    }
}
