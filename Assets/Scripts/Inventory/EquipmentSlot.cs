using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    public EquipmentSlotType type;

    private ItemData itemData;

    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        itemData = data;
        defaultIcon.enabled = false;
        itemIcon.enabled = true;
        itemIcon.sprite = data.icon;
        // Make sure to apply the attributes once an item is equipped
        InventoryManager.Instance.player.AddAttributes(data.attributes);
    }

    public void Unequip()
    {
        // TODO
        // Check if there is an available inventory slot before removing the item.
        // Make sure to return the equipment to the inventory when there is an available slot.
        // Reset the item data and icons here
        int x = InventoryManager.Instance.GetEmptyInventorySlot();
        if(x <= 4)
        {
            if(itemData != null) //prevents bug that calls Unequip function when pressing Spacebar immediately after using an item
            {
                InventoryManager.Instance.inventorySlots[x].SetItem(itemData);
                InventoryManager.Instance.player.RemoveAttributes(itemData.attributes); //MUST run before itemData = null
                itemData = null;
                defaultIcon.enabled = true;
                itemIcon.enabled = false;
                itemIcon.sprite = null;
            }
            
        }
    }
}
