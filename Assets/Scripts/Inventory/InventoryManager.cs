using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int i, inv, e;

    public Player player;
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public void UseItem(ItemData data)
    {
        // TODO
        // If the item is a consumable, simply add the attributes of the item to the player.
        /*
        if(data.type == 0)
        {
            player.AddAttributes(data.attributes);
        }
        // If it is equippable, get the equipment slot that matches the item's slot.
        // Set the equipment slot's item as that of the used item
        else
        {
            for(e = 0; e <= 4; e++)
            {
                //Debug.Log($"e = {e} = {equipmentSlots[e].type}");
                if(equipmentSlots[e].type == data.slotType)
                {
                    equipmentSlots[e].SetItem(data);
                    //Debug.Log($"e final = {e} = {equipmentSlots[e].type}");
                    break;
                }
            }
        }
        */
        switch(data.type)
        {
            case ItemType.Consumable:
                player.AddAttributes(data.attributes);
                break;
            case ItemType.Equipabble:
                for(e = 0; e <= 4; e++)
                {
                    //Debug.Log($"e = {e} = {equipmentSlots[e].type}");
                    if(equipmentSlots[e].type == data.slotType)
                    {
                        equipmentSlots[e].SetItem(data);
                        //Debug.Log($"e final = {e} = {equipmentSlots[e].type}");
                        break;
                    }
                }
                break;
            case ItemType.Quest:
                //nothing happens - prevention of use is at InventorySlots.cs
                break;
        }
    }

   
    public void AddItem(string itemID)
    {
        //TODO
        //1. Cycle through every item in the database until you find the item with the same id.
        for(i = 0; itemDatabase[i].id != itemID; i++)
        {

        }
        //Debug.Log($"i = {i}");
        //2. Get the index of the InventorySlot that does not have any Item and set its Item to the Item found
        inventorySlots[GetEmptyInventorySlot()].SetItem(itemDatabase[i]);
        //Debug.Log($"inv = {inv} = {inventorySlots[inv].itemData.id}");
    }

    public int GetEmptyInventorySlot()
    {
        //TODO
        //Check which inventory slot doesn't have an Item and return its index
        
        for(inv = 0; inv <= 4; inv++)
        {
            //Debug.Log($"inv = {inv}");
            if(inventorySlots[inv].itemData == null || inventorySlots[inv].itemData.id == "")
            {
                //Debug.Log($"inv final = {inv}");
                break; //prevents inv from incrementing
            }
        }
        return (inv);
        /*
        for(inv = 0; inv <= 4; inv++)
        {
            Debug.Log($"inv = {inv}");
            if(inventorySlots[inv].HasItem() == true)
            {
                break;
            }
        }
        Debug.Log($"inv final = {inv}");
        return (inv);
        */
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        //TODO
        //Check which equipment slot matches the slot type and return its index
        return -1;
    }
}
