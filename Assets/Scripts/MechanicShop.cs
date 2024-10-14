using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
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

    private int[] partPrices = { 600, 100, 150, 50, 85 };
    private string[] partNames = { "Engine", "Tire", "Mirrors", "Paint", "Oil" };
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
        Debug.Log("part is " + partNames[partIndex] + " and costs " + partPrices[partIndex]);
        if (partIndex < partPrices.Length)
        {
            string selectedPart = partNames[partIndex];
            int price = partPrices[partIndex];

            if (CanAfford(price))
            {
                Debug.Log("buying part!");
                SubtractCoins(price);
                AddToInventory(selectedPart); //havent implemented yet
            } else {
                Debug.Log("failed to buy part.");
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
        if (price <= totalCoins) {
            return true;
        }
        return false;
    }
    public void SubtractCoins(int price)
    {
        
        if (totalCoins >= price)
        {
            Debug.Log("in thing");
            totalCoins -= price;
            UpdateCoinText();
            warningText.text = "";
        }
        Debug.Log("price is: " + price);
        Debug.Log("total coins: " + totalCoins);
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
        return;
}
}

