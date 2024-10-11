using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class PipeRotatation : MonoBehaviour
{
    public GameObject[] pipeArray;
    public GameObject[] selectionBox;
    public static GameObject selectedPipe = null;
    public int pipeId = -1;
    public bool pipeIsSelected = false;
    //Start is called before the first frame update
    void Start()
    {
        SelectionBoxStart();
        PipeRotateStart();
    }
    //Update is called once per frame
    void Update()
    {
        SelectionBoxSelect();
        PipeRotator();
    }
    //hide all selection boxes to start
    void SelectionBoxStart() {
        for (int i = 0; i < 21; i++) selectionBox[i].SetActive(false);
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
            //rotate pipe at index according to random values
            pipeArray[possible[index]].transform.Rotate(0.0f, 0.0f, zAngleArray[randRotate]);
            possible.RemoveAt(index);
        }
    }
    void SelectionBoxSelect() {
        //detect mouse button down
        string pipeName = "";
        string pipeNum = "";
        if (Input.GetMouseButtonDown(0)) {
            if (pipeIsSelected == true) {
                selectionBox[pipeId].SetActive(false);
                pipeIsSelected = false;
            }
            //create a ray from camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //perform ray cast
            if (Physics.Raycast(ray, out hit)) {
                //detect if ray has hit a collider
                selectedPipe = hit.collider.gameObject;
                //do things with the selected pipe
                Debug.Log("Selected Pipe: " + selectedPipe.name);
                //convert selected pipe to an index
                pipeName = selectedPipe.name;
                pipeNum  = pipeName.Substring(5);
                int new_pipeId = Int32.Parse(pipeNum) - 1;
                //turn off previous selected pipe
                //show selection box according to gameObject selected
                if (pipeIsSelected == false && pipeId != new_pipeId) {
                    pipeId = new_pipeId;
                    selectionBox[pipeId].SetActive(true);
                    pipeIsSelected = true;
                }
                else if (pipeId == new_pipeId) {
                    selectionBox[pipeId].SetActive(false);
                    pipeIsSelected = false;
                    pipeId = -1;
                }
                Debug.Log("Pipe Number: " + pipeId);
            }
        }
    }
    void PipeRotator() {
        if (pipeId >= 0) {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && pipeIsSelected == true)
            {
                pipeArray[pipeId].transform.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
    }
}