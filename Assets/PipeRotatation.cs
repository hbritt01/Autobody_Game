using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class PipeRotatation : MonoBehaviour
{
    public GameObject[] pipeArray;
    public int index;
    public int randRotate; 
    //Start is called before the first frame update
    void Start()
    {
        PipeRotateStart();
    }
    //pick random pipes to rotate x degrees
    void PipeRotateStart()
    {
        List<int> possible = Enumerable.Range(0, 20).ToList();
        float[] zAngleArray = {90.0f, 180.0f, 270.0f};
        System.Random randomNum = new System.Random();
        int index;
        int randRotate;
        for (int i = 0; i < 18; i++) {
            //pick random pipe from rem. possible list, pick random rotate angle
            index = randomNum.Next(0, possible.Count);
            randRotate = randomNum.Next(0, 3);
            //rotate pipe at index according to random balues
            pipeArray[possible[index]].transform.Rotate(0.0f, 0.0f, zAngleArray[randRotate]);
            Debug.Log("Pipe " + possible[index] + " rotated " + randRotate);
            possible.RemoveAt(index);
        }
    }
    //Update is called once per frame
    void Update()
    {
        
    }
}
