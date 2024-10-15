using UnityEngine;
using UnityEngine.UI;

public class GarageManager : MonoBehaviour
{
    public Text coinText; 
    private int totalCoins;

    void Start()
    {
      
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 1000); 

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
