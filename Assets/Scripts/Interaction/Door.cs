using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        int i, keySlot = 0;
        bool keyFound = false;
        for(i = 0; i < InventoryManager.Instance.inventorySlots.Count; i++)
        {
            if(InventoryManager.Instance.inventorySlots[i].itemData != null && InventoryManager.Instance.inventorySlots[i].itemData.id == "Key")
            {
                keySlot = i;
                keyFound = true;
            }
        }
        if(keyFound == true)
        {
            InventoryManager.Instance.inventorySlots[keySlot].itemIcon.enabled = false;
            InventoryManager.Instance.inventorySlots[keySlot].itemIcon.sprite = null;
            InventoryManager.Instance.inventorySlots[keySlot].itemData = null;

            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Door is Locked");
        }
    }
}
