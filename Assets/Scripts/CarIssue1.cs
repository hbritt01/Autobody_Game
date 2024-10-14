using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIssue1 : MonoBehaviour
{

    private int numProblems;
    private List<string> thatCarsProblems;
    // private string carProblems[] = {"Flat Tire" , "Exploded Engine" , "Oil Change Required" , "Paint Job Wanted", "Mirror Smashed"};
    // Start is called before the first frame update
    void Start()
    {
        SetProblems();
        
    }
    void SetProblems()
    {
        numProblems = Random.Range(0,4);

        Debug.Log("We have " + numProblems + " problems");
        ArrayList carProblems = new ArrayList(); 
        carProblems.Add("Flat Tire");
        carProblems.Add("Exploded Engine");
        carProblems.Add("Oil Change Required");
        carProblems.Add("Paint Job Wanted");
        carProblems.Add("Mirror Smashed");

        for (int i = 0; i < numProblems; i++) {  
            // string issue = (string)carProblems[i];
            thatCarsProblems.Add((string)carProblems[i]);
            carProblems.RemoveAt(i);
        }
    }
    // Update is called once per frame
}
