using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarIssue : MonoBehaviour
{
    public Text issueText;
    private string[] carIssues = { "Engine", "Tire", "Broken Passenger Mirror", "Broken Driver Mirror" };
    private bool issueResolved = true;
    private string currentIssue;

    void OnMouseDown()
    {
        if (issueResolved)
        {
            currentIssue = carIssues[Random.Range(0, carIssues.Length)];
            issueText.text = "Car Issue:\n" + currentIssue;
            issueResolved = false;
        }
        else
        {
            Debug.Log("Please fix the current issue before generating a new one.");
        }
    }

    public bool TryFixIssue(string partName)
    {
        if (partName.Trim().ToLower() == currentIssue.Trim().ToLower())
        {
            FixCurrentIssue();
            return true;
        }
        return false;
    }

    public void FixCurrentIssue()
    {
        issueResolved = true;
        issueText.text = "Car Issue\nResolved!";
    }
}

