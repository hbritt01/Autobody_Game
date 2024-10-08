using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Inventory : MonoBehaviour
{
    //let string be item, int be index. Each item maps to a diff index
    //let there be 10 for now
    int maxItems = 10;
    var itemPair = new List<KeyValuePair>string, int>>();
    private List<itemPair> items = new List<itemPair>();
    public Text inventoryText;

    // add an item to the inventory
    public void AddItem(itemPair item)
    {
            items.Add(item);
            UpdateInventoryUI();
    }

    // remove an item from the inventory
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            UpdateInventoryUI();
        }
        else
        {
            Debug.Log(item + " is not in the inventory.");
        }
    }

    // Method to update the inventory UI text
    private void UpdateInventoryUI()
    {
        if (inventoryText != null)
        {
            inventoryText.text = "Current Inventory:\n";
            if (items.Count == 0)
            {
                inventoryText.text += "Inventory is empty.";
            }
            else
            {
                foreach (string item in items)
                {
                    inventoryText.text += "- " + item + "\n";
                }
            }
        }
    }
}