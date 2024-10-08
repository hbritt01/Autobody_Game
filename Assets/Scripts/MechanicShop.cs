using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MechanicShop : MonoBehaviour
{
    public int totalCoins = 1000;
    public Text coinText;
    public Text warningText;

    public Dropdown partDropdown;
    public CarIssue carIssue;  // Drag the CarIssue object here

    private int[] partPrices = { 0, 100, 200, 300 };
    private string[] partNames = { "Engine", "Tire", "Broken Passenger Mirror", "Broken Driver Mirror" };

    void Start()
    {
        UpdateCoinText();
        warningText.text = "";

        partDropdown.onValueChanged.AddListener(delegate {
            OnDropdownValueChanged(partDropdown);
        });
    }

    void OnDropdownValueChanged(Dropdown dropdown)
    {
        int dropdownIndex = dropdown.value;

        if (dropdownIndex < partPrices.Length)
        {
            string selectedPart = partNames[dropdownIndex];
            int price = partPrices[dropdownIndex];

            // Try to fix the issue first before subtracting coins
            bool issueFixed = carIssue.TryFixIssue(selectedPart);

            if (issueFixed)
            {
                SubtractCoins(price);
                ShowTemporaryMessage("Issue Fixed!", 2f);  // Show message for 2 seconds
            }
            else
            {
                ShowTemporaryMessage("Part doesn't fix the issue! Coins not deducted.", 2f);  // Show message for 2 seconds
            }
        }
    }

    public void SubtractCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            UpdateCoinText();
            warningText.text = "";
        }
        else
        {
            ShowTemporaryMessage("Not enough coins!", 2f);  // Show message for 2 seconds
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }

    // Coroutine to show the message for a limited time
    private void ShowTemporaryMessage(string message, float duration)
    {
        StartCoroutine(HideMessageAfterDelay(message, duration));
    }

    private IEnumerator HideMessageAfterDelay(string message, float duration)
    {
        // Display the message
        warningText.text = message;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Clear the message
        warningText.text = "";
    }
}
