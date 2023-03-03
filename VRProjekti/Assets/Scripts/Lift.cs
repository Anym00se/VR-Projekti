using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private float liftMovementSpeed = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RaiseLift();
        }
        if (Input.GetKey(KeyCode.S))
        {
            LowerLift();
        }
    }

    public void RaiseLift(float speed = 0f)
    {
        if (speed == 0) { speed = liftMovementSpeed; }
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public void LowerLift(float speed = 0f)
    {
        if (speed == 0) { speed = liftMovementSpeed; }
        transform.position -= Vector3.up * speed * Time.deltaTime;

        // Limit lift y position
        if (transform.position.y <= -0.49)
        {
            transform.position = new Vector3(
                transform.position.x,
                -0.49f,
                transform.position.z
            );
        }
    }
}
