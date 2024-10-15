using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move2 : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(5, 1, 0);
    public Vector3 startPosition = new Vector3(-10, -2, 0);
    public float moveSpeed = 4.0f;
    private bool shouldMove = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            transform.position = startPosition;
            shouldMove = true;
        }

        if (shouldMove)
        {
            // Move the object toward the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving once it reaches the target position
            if (transform.position == targetPosition)
            {
                shouldMove = false;
            }
        }
    }
}