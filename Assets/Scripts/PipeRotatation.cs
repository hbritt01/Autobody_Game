using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PipeRotatation : MonoBehaviour
{
    public GameObject[] pipeArray;
    public GameObject[] selectionBox;
    public static GameObject selectedPipe = null;
    public GameObject gameOverScreen;
    public int pipeId = -1;
    public int correctPipes = 21;
    public bool pipeIsSelected = false;
    public bool pipeSelectionEnabled;
    bool[] pipeDirectionSuccess = new bool[21];
    //Start is called before the first frame update
    void Start()
    {
        SelectionBoxStart();
        PipeRotateStart();
        gameOverScreen.SetActive(false);
        pipeSelectionEnabled = true;
    }
    //Update is called once per frame
    void Update()
    {
        SelectionBoxSelect();
        PipeRotator();
        //show success screen
        if (correctPipes == 21)
            returnToMainScene();
    }
    //hide all selection boxes to start
    void SelectionBoxStart() {
        for (int i = 0; i < 21; i++) {
            selectionBox[i].SetActive(false);
            pipeDirectionSuccess[i] = true;
        }
    }
    //pick random pipes to rotate x degrees
    void PipeRotateStart()
    {
        List<int> possible = Enumerable.Range(0, 21).ToList();
        float[] zAngleArray = {90.0f, 180.0f, 270.0f};
        System.Random randomNum = new System.Random();
        int index;
        int randRotate;
        int[] rotatedPipes = new int[18];
        Debug.Log("Pipes Rotated: ");
        for (int i = 0; i < 18; i++) {
            //pick random pipe from rem. possible list, pick random rotate angle
            index = randomNum.Next(0, possible.Count);
            randRotate = randomNum.Next(0, 3);
            //rotate pipe at index according to random values
            pipeArray[possible[index]].transform.Rotate(0.0f, 0.0f, zAngleArray[randRotate]);
            pipeDirectionSuccess[possible[index]] = false;
            rotatedPipes[i] = possible[index];
            Debug.Log(rotatedPipes[i]);   
            possible.RemoveAt(index);
            correctPipes--;
        }
    }
    void SelectionBoxSelect() {
        if (pipeSelectionEnabled)
        {
            //detect mouse button down
            string pipeName = "";
            string pipeNum = "";
            if (Input.GetMouseButtonDown(0)) 
            {
                if (pipeIsSelected) 
                {
                    selectionBox[pipeId].SetActive(false);
                    pipeIsSelected = false;
                }
                //create a ray from camera through the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //perform ray cast
                if (Physics.Raycast(ray, out hit)) 
                {
                    //detect if ray has hit a collider
                    selectedPipe = hit.collider.gameObject;
                    //do things with the selected pipe
                    //convert selected pipe to an index
                    pipeName = selectedPipe.name;
                    pipeNum  = pipeName.Substring(5);
                    int new_pipeId = Int32.Parse(pipeNum) - 1;
                    //turn off previous selected pipe
                    //show selection box according to gameObject selected
                    if (!pipeIsSelected && pipeId != new_pipeId) 
                    {
                        pipeId = new_pipeId;
                        selectionBox[pipeId].SetActive(true);
                        pipeIsSelected = true;
                    }
                    else if (pipeId == new_pipeId) 
                    {
                        selectionBox[pipeId].SetActive(false);
                        pipeIsSelected = false;
                        pipeId = -1;
                    }
                }
                Debug.Log("Pipe ID: " + pipeId);
            }
        }
    }
    void PipeRotator() {
        if (pipeId >= 0) 
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && pipeIsSelected)
            {
                pipeArray[pipeId].transform.Rotate(0.0f, 0.0f, 90.0f);
                if (pipeId >= 0)
                {
                    if (!pipeDirectionSuccess[pipeId]) 
                    {
                        if (((pipeId >= 0 && pipeId < 4) || (pipeId >= 8 && pipeId < 12) || (pipeId >= 16 && pipeId < 21)) && pipeArray[pipeId].transform.eulerAngles.z == 180.0f) 
                        {
                            correctPipes++;
                            pipeDirectionSuccess[pipeId] = true;
                            Debug.Log("Correct Pipes +1");
                            Debug.Log("Total Correct Pipes: " + correctPipes);
                        }
                        else if (((pipeId >= 4 && pipeId < 8) || (pipeId >= 12 && pipeId < 16)) && pipeArray[pipeId].transform.eulerAngles.z == 0.0f) 
                        {
                            correctPipes++;
                            pipeDirectionSuccess[pipeId] = true;
                            Debug.Log("Correct Pipes +1");
                            Debug.Log("Total Correct Pipes: " + correctPipes);
                        }
                    }
                    else
                    {
                        correctPipes--;
                        pipeDirectionSuccess[pipeId] = false;
                        Debug.Log("Correct Pipes -1");
                        Debug.Log("Total Correct Pipes: " + correctPipes);
                    }
                }
            }
        }
    }
    void returnToMainScene() {
        gameOverScreen.SetActive(true);
        pipeSelectionEnabled = false;
        if (Input.anyKey) 
            SceneManager.LoadScene("SampleScene");
    }
}