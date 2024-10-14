using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarIssue1 : MonoBehaviour
{

    private int numProblems;
    [SerializeField] private List<string> thatCarsProblems;
    [SerializeField] private Dropdown cardropdown;

    // public BoxCollider2D collision;
    // private string carProblems[] = {"Flat Tire" , "Exploded Engine" , "Oil Change Required" , "Paint Job Wanted", "Mirror Smashed"};
    // Start is called before the first frame update
    void Start()
    {
        SetProblems();
        setDropdown();
    }
    void SetProblems()
    {
        numProblems = Random.Range(1,4);
        Debug.Log("We have " + numProblems + " problems");
        ArrayList carProblems = new ArrayList(); 
        carProblems.Add("Flat Tire");
        carProblems.Add("Exploded Engine");
        carProblems.Add("Oil Change Required");
        carProblems.Add("Paint Job Wanted");
        carProblems.Add("Mirror Smashed");

        for (int i = 0; i < numProblems; i++) {  
            // string issue = (string)carProblems[i];
            Debug.Log("NumProblems: " + numProblems);
            thatCarsProblems.Add((string)carProblems[i]);
            carProblems.RemoveAt(i);
            foreach (string s in thatCarsProblems) {
                Debug.Log("Problem is " + s);
            }
        }
    }

    void setDropdown()
    {
        // Dropdown cardropdown = GetComponent<Dropdown>();
        foreach (string s in thatCarsProblems) {
            cardropdown.ClearOptions();
            cardropdown.AddOptions(thatCarsProblems);
        }

    }
    void ShowMenu()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
        { 
            Debug.Log("ran into car");
        }
}
