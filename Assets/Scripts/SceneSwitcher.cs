using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public MechanicShop mechanicShop;

    public void GoToGarageScene()
    {
        if (mechanicShop != null)
        {
            if (mechanicShop.totalCoinsSpent >= 400)
            {
                if (mechanicShop.totalCoins >= 10000)
                {
                    Debug.Log("Player has 10,000 or more coins. Loading EndOfGame scene.");
                    SceneManager.LoadScene("EndOfGame");
                }
                else
                {
                    PlayerPrefs.SetInt("TotalCoins", mechanicShop.totalCoins);
                    PlayerPrefs.SetInt("TotalCoinsSpent", mechanicShop.totalCoinsSpent);
                    PlayerPrefs.Save();

                    Debug.Log("Coins saved when going to garage: " + mechanicShop.totalCoins);

                    SceneManager.LoadScene("Garage1");
                }
            }
            else
            {
                mechanicShop.ShowTemporaryMessage("You must spend at least 400 coins before going to the garage!", 2f);
            }
        }
        else
        {
            Debug.LogError("MechanicShop reference is not set!");
        }
    }

    public void GoToShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
}
