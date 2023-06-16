using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected 
        int x = InventoryManager.Instance.GetEmptyInventorySlot();
        if(x <= 4) //checks if any of the 5 inventory slots are empty
        {
            InventoryManager.Instance.AddItem(id);
            Destroy(gameObject);
        }
        
    }
}
