using UnityEngine;
using UnityEngine.UI;

public class MechanicShop : MonoBehaviour
{
    public int totalCoins = 1000;
    public Text coinText;
    public Text warningText;

    public Dropdown partDropdown;

    private int[] partPrices = { 0, 100, 200, 300 };

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
            int price = partPrices[dropdownIndex];
            if (price > 0)
            {
                SubtractCoins(price);
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
            warningText.text = "Not enough coins!";
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }
}
