using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInventory_SO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
}
