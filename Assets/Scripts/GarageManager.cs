using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Add this for List<> support

public class GarageManager : MonoBehaviour
{
    public Text coinText;
    private int totalCoins;
    private List<string> inventory = new List<string>();

    void Start()
    {
        // Load saved coins and inventory from PlayerPrefs
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 600); 
        string savedInventory = PlayerPrefs.GetString("Inventory", ""); 

        if (!string.IsNullOrEmpty(savedInventory))
        {
            inventory = new List<string>(savedInventory.Split(',')); // Convert the saved string back to a list
        }

        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins.ToString();
        }
    }
}
