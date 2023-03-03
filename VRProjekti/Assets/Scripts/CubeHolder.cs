using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField] private GameObject StackCube_Prefab;
    [SerializeField] private Transform spawnTransform;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnCube();
        }
    }

    void SpawnCube()
    {
        Instantiate(StackCube_Prefab, spawnTransform.position, GetRandomRotation());
    }

    Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(
            Random.Range(0f, 180f),
            Random.Range(0f, 180f),
            Random.Range(0f, 180f)
        );
    }
}
