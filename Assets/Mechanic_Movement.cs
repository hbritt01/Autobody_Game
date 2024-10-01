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
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //the listener for player input goes in the Update() function
        // if (Input.GetKeyDown("w")){
        //     Move("w");
        //     transform.Translate(.001, 0, 0);
        // } else if (Input.GetKeyDown("a")){
        //     Move("a");
        // } else if (Input.GetKeyDown("s")){
        //     Move("s");
        // } else if (Input.GetKeyDown("d")){
        //     Move("d");
        // }
    }

    public void Move(string str){
        Debug.Log(str);
    }
}