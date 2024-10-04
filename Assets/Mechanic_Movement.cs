using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mechanic_Movement : MonoBehaviour {

    public float moveSpeed = 10f; // Speed of movement

    void Update(){

        float moveX = Input.GetAxis("Horizontal"); // A and D or Left/Right Arrow keys
        float moveY = Input.GetAxis("Vertical");   // W and S or Up/Down Arrow keys

        // Create movement vector
        Vector3 movement = new Vector3(moveX, moveY, 0);

        // Move the player object
        //TO-DO:
        //Set boundaries for the mechanic
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    public void Move(string str){
        Debug.Log(str);
    }
}