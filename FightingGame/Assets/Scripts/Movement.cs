using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;

    public bool isTakingInput = true;

    public Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        // pull data from the database.
        PullData();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTakingInput)
        {
            movementVector = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                movementVector += new Vector3(0f, 0f, 1f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementVector += new Vector3(0f, 0f, -1f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementVector += new Vector3(-1f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                movementVector += new Vector3(1f, 0f, 0f);
            }

            movementVector *= movementSpeed;

            // Apply movement vector to entity
            transform.Translate(movementVector * Time.deltaTime);
        }
    }

    public void PullData()
    {
        // Use Andy's class to pull data.


        // Apply data pulled
        movementSpeed = 1f;
    }
}
