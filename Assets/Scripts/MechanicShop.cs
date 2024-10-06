using UnityEngine;
using UnityEngine.UI;

public class MechanicShop : MonoBehaviour
{
    public int totalCoins = 1000;
    public Text coinText;
    public Dropdown partDropdown;

    void Start()
    {
        UpdateCoinText();

        partDropdown.onValueChanged.AddListener(delegate {
            OnDropdownValueChanged(partDropdown);
        });
    }

    void OnDropdownValueChanged(Dropdown dropdown)
    {
        int dropdownIndex = dropdown.value;

        switch (dropdownIndex)
        {
            case 0:
                Debug.Log("No action for the first option.");
                break;
            case 1:
                SubtractCoins(100);
                break;
            case 2:
                SubtractCoins(200);
                break;
            default:
                Debug.Log("No action for this selection.");
                break;
        }
    }

    public void SubtractCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            Debug.Log("Subtracted " + amount + " coins. Remaining coins: " + totalCoins);
            UpdateCoinText();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }
}
