using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 

public class MechanicShop : MonoBehaviour
{
    public int totalCoins = 1000;
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

    void Start()
    {
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
        if (totalCoins >= price)
        {
            totalCoins -= price;
            UpdateCoinText();
            warningText.text = "";
        }
        Debug.Log("Price is: " + price);
        Debug.Log("Total coins: " + totalCoins);
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }

    private void ShowTemporaryMessage(string message, float duration)
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
}
