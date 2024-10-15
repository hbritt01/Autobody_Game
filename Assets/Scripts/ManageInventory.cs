using UnityEngine;
using UnityEngine.UI;

public class ManageInventory : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public Text inventoryText;       

    private bool isInventoryOpen = false; 

    public void ToggleInventory()
    {
        Debug.Log("Inventory button clicked.");
       
        if (inventoryPanel == null)
        {
            Debug.LogError("Inventory panel is not assigned!");
            return;
        }

        if (inventoryText == null)
        {
            Debug.LogError("Inventory text is not assigned!");
            return;
        }

        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            DisplayInventory();
        }
    }

   public void DisplayInventory()
   {
       if (MechanicShop.inventory != null && MechanicShop.inventory.Count > 0)
       {
           string inventoryContents = string.Join(", ", MechanicShop.inventory);
           inventoryText.text = "" + inventoryContents; 
           Debug.Log("Inventory Contents: " + inventoryContents); 
       }
       else
       {
           inventoryText.text = "Inventory is empty."; 
       }
   }

   public void FixCarInInventory()
   {
       Debug.Log("Inventory fix car logic here...");
   }
}

