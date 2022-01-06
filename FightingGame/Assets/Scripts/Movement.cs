using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 0f;

    public bool isTakingInput = true;

    public Vector3 movementVector;

    public void Start()
    {
        DataManager.instance.dataPulled += OnDataPulled;
    }

    private void OnDisable()
    {
        DataManager.instance.dataPulled -= OnDataPulled;
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

    public void OnDataPulled(object sender, EventArgs e)
    {
        
        movementSpeed = DataManager.instance.HeroStat.MovementSpeed;
        Debug.Log("Successfully pulled data! updating movement speed for hero: " + movementSpeed);
    }
}
