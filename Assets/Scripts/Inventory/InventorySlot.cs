using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        if(data != null) //prevents bug that calls SetItem function when pressing Spacebar immediately after using an item
        {
            itemData = data;
            itemIcon.enabled = true;
            itemIcon.sprite = data.icon;
        }
        
    }

    public void UseItem()
    {
        if(itemData != null)
        {
            InventoryManager.Instance.UseItem(itemData);
            // TODO
            // Reset the item data and the icons here
            if(itemData.type != ItemType.Quest) //prevents ItemType.Quest from being used
            {
                itemIcon.enabled = false;
                itemIcon.sprite = null;
                itemData = null;
            }
        }
    }

    public bool HasItem()
    {
        return itemData != null;
        /*
        if(itemData != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        */
    }
}
