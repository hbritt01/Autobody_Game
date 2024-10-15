using UnityEngine;
using UnityEngine.UI;

public class CarProblemGenerator : MonoBehaviour
{
    public Text problemText1;
    public Text problemText2;

    public GameObject problemPanel;

    private string[] carProblems = { "Engine Issue", "Flat Tire", "Broken Passenger Mirror", "Broken Driver Mirror", "Paint Scratch", "Oil Leak" };

    private string[] partNames = { "Engine", "Tire", "Mirrors", "Mirrors", "Paint", "Oil" };

    private string currentProblem1;
    private string currentProblem2;

    void Start()
    {
        problemPanel.SetActive(false);
    }

    public void TogglePanelAndGenerateProblems()
    {
        if (problemPanel.activeSelf)
        {
            problemPanel.SetActive(false);
        }
        else
        {
            GenerateRandomCarProblems();
            problemPanel.SetActive(true);
        }
    }

    private void GenerateRandomCarProblems()
    {
        int problemIndex1 = Random.Range(0, carProblems.Length);
        int problemIndex2;

        do
        {
            problemIndex2 = Random.Range(0, carProblems.Length);
        } while (problemIndex1 == problemIndex2); 

        currentProblem1 = carProblems[problemIndex1];
        currentProblem2 = carProblems[problemIndex2];

        problemText1.text = "Problem 1: " + currentProblem1;
        problemText2.text = "Problem 2: " + currentProblem2;

        Debug.Log("Generated problems: " + currentProblem1 + " and " + currentProblem2);
    }

    public bool CanFixCar()
    {
        string partForProblem1 = partNames[System.Array.IndexOf(carProblems, currentProblem1)];
        string partForProblem2 = partNames[System.Array.IndexOf(carProblems, currentProblem2)];

        return MechanicShop.inventory.Contains(partForProblem1) && MechanicShop.inventory.Contains(partForProblem2);
    }

   public void FixCar()
{
    if (CanFixCar())
    {
        string partForProblem1 = partNames[System.Array.IndexOf(carProblems, currentProblem1)];
        string partForProblem2 = partNames[System.Array.IndexOf(carProblems, currentProblem2)];

        MechanicShop.inventory.Remove(partForProblem1);
        MechanicShop.inventory.Remove(partForProblem2);

        Debug.Log("Car fixed! Removed " + partForProblem1 + " and " + partForProblem2 + " from inventory.");
        problemText1.text = "Problem 1: Fixed!";
        problemText2.text = "Problem 2: Fixed!";

       
        ManageInventory inventoryManager = GameObject.FindObjectOfType<ManageInventory>();
        if (inventoryManager != null)
        {
            inventoryManager.DisplayInventory(); 
        }
    }
    else
    {
        Debug.Log("You don't have the required items to fix the car.");
    }
}
}
