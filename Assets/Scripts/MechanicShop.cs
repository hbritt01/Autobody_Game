using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic; 
using UnityEngine.SceneManagement; 

public class MechanicShop : MonoBehaviour
{
    public int totalCoins = 600; 
    public Text coinText;
    public Text warningText;
    public Text engButtonText;
    public Text tireButtonText;
    public Text MirrButtonText;
    public Text PaintButtonText;
    public Text OilButtonText;

    private int[] partPrices = { 400, 100, 150, 50, 85 };
    private string[] partNames = { "Engine", "Tire", "Mirrors", "Paint", "Oil" };

    public static List<string> inventory = new List<string>();

    public int totalCoinsSpent = 0; 

    void Start()
    {
        if (PlayerPrefs.GetInt("IsNewGame", 1) == 1)
        {
            totalCoins = 1000;
            PlayerPrefs.SetInt("TotalCoins", totalCoins); 
            PlayerPrefs.SetInt("IsNewGame", 0); 
            PlayerPrefs.Save();
        }
        else
        {
            totalCoins = PlayerPrefs.GetInt("TotalCoins", 1000);
            totalCoinsSpent = PlayerPrefs.GetInt("TotalCoinsSpent", 0); 
        }

        PopulatePartButtons();
        UpdateCoinText();
        warningText.text = "";
    }

    void PopulatePartButtons() 
    {
        engButtonText.text = partNames[0] + ": " + partPrices[0];
        tireButtonText.text = partNames[1] + ": " + partPrices[1];
        MirrButtonText.text = partNames[2] + ": " + partPrices[2];
        PaintButtonText.text = partNames[3] + ": " + partPrices[3];
        OilButtonText.text = partNames[4] + ": " + partPrices[4];
    }
    
    void BuyPart(int partIndex)
    {
        if (partIndex < partPrices.Length)
        {
            string selectedPart = partNames[partIndex];
            int price = partPrices[partIndex];

            if (CanAfford(price))
            {
                Debug.Log("Buying part: " + selectedPart);
                SubtractCoins(price);
                AddToInventory(selectedPart); 
            }
            else
            {
                Debug.Log("Failed to buy part.");
                ShowTemporaryMessage("Not enough coins!", 2f);
            }
        }
    }

    public void engButton()
    {
        Debug.Log("Engine button clicked.");
        BuyPart(0);
    }

    public void TireButton()
    {
        BuyPart(1);
    }

    public void MirrButton()
    {
        BuyPart(2);
    }

    public void PaintButton()
    {
        BuyPart(3);
    }

    public void OilButton()
    {
        BuyPart(4);
    }

    bool CanAfford(int price)
    {
        return price <= totalCoins;
    }

    public void SubtractCoins(int price)
    {
        Debug.Log("Attempting to subtract coins... Current coins: " + totalCoins + " Price: " + price);

        if (totalCoins >= price)
        {
            totalCoins -= price;
            totalCoinsSpent += price; 

            PlayerPrefs.SetInt("TotalCoins", totalCoins); 
            PlayerPrefs.SetInt("TotalCoinsSpent", totalCoinsSpent); 
            PlayerPrefs.Save(); 
            UpdateCoinText();
            warningText.text = "";

            Debug.Log("Coins saved in shop: " + totalCoins);
            Debug.Log("Total coins spent: " + totalCoinsSpent);
        }
        else
        {
            Debug.Log("Not enough coins to make the purchase.");
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }

    public void ShowTemporaryMessage(string message, float duration)
    {
        StartCoroutine(HideMessageAfterDelay(message, duration));
    }

    private IEnumerator HideMessageAfterDelay(string message, float duration)
    {
        warningText.text = message;
        yield return new WaitForSeconds(duration);
        warningText.text = "";
    }

    void AddToInventory(string carPart)
    {
        inventory.Add(carPart);
        Debug.Log("Added " + carPart + " to inventory.");
        DisplayInventory(); 
    }

    void DisplayInventory()
    {
        Debug.Log("Current Inventory: " + string.Join(", ", inventory));
    }

    public void GoToGarage()
    {
        if (totalCoinsSpent >= 400)
        {
            Debug.Log("Going to garage...");
            SceneManager.LoadScene("GarageScene"); 
        }
        else
        {
            ShowTemporaryMessage("You must spend at least 400 coins before going to the garage!", 2f);
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.SetInt("TotalCoinsSpent", totalCoinsSpent); 
        PlayerPrefs.Save();
        Debug.Log("Coins saved on scene exit: " + totalCoins);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("IsNewGame", 1);
        PlayerPrefs.Save();
    }
}
