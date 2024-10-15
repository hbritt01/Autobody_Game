using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitcher : MonoBehaviour
{
    public MechanicShop mechanicShop; 

   
    public void GoToGarageScene()
    {
        if (mechanicShop != null)
        {
            
            PlayerPrefs.SetInt("TotalCoins", mechanicShop.totalCoins);
            PlayerPrefs.Save(); 

            Debug.Log("Coins saved when going to garage: " + mechanicShop.totalCoins);
        }
        else
        {
            Debug.LogError("MechanicShop reference is not set!");
        }

      
        SceneManager.LoadScene("Garage1");
    }

   
    public void GoToShopScene()
    {
        SceneManager.LoadScene("Shop"); 
    }
}
