using UnityEngine;
using UnityEngine.UI;

public class MechanicShop : MonoBehaviour
{
    public int totalCoins = 1000;
    public Text coinText;  // Existing text for displaying total coins
    public Text warningText;  // New text field for displaying warnings (add this)

    public Dropdown partDropdown;

    // Array to store the price of each part in the dropdown
    private int[] partPrices = { 0, 100, 200, 300 };  // Set prices for each option (adjust as needed)

    void Start()
    {
        UpdateCoinText();
        warningText.text = "";  // Clear the warning text at the start

        partDropdown.onValueChanged.AddListener(delegate {
            OnDropdownValueChanged(partDropdown);
        });
    }

    void OnDropdownValueChanged(Dropdown dropdown)
    {
        int dropdownIndex = dropdown.value;

        if (dropdownIndex < partPrices.Length)  // Ensure the index is within the range of the prices array
        {
            int price = partPrices[dropdownIndex];  // Get the price for the selected part
            if (price > 0)
            {
                SubtractCoins(price);
            }
            else
            {
                Debug.Log("No action for the first option or invalid option.");
            }
        }
    }

    public void SubtractCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            Debug.Log("Subtracted " + amount + " coins. Remaining coins: " + totalCoins);
            UpdateCoinText();
            warningText.text = "";  // Clear the warning if the transaction is successful
        }
        else
        {
            Debug.Log("Not enough coins!");
            warningText.text = "Not enough coins!";  // Display warning message
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }
}
