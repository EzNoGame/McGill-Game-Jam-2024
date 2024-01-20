using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public int toolbarSlots;
    public InventorySlot[] slots;
    public GameObject invItemPrefab;
    public int selectedSlot = 0;


    public void Update()
    {
        // scrollwheel change slot
        if (Input.GetAxis("Mouse ScrollWheel") > 0)  //forward scroll
        {
            if (selectedSlot >= toolbarSlots - 1)
            {
                ChangeSelectedSlot(0);
            }
            else
            {
                ChangeSelectedSlot(selectedSlot + 1);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) //backwards scroll
        {
            Debug.Log("scroll");
            if (selectedSlot <= 0)
            {
                ChangeSelectedSlot(toolbarSlots-1);
            } 
            else
            {
                ChangeSelectedSlot(selectedSlot - 1);
            }
        }

        // number key change slot
        if (Input.inputString != null)
        {
            
            bool isNum = int.TryParse(Input.inputString, out int num);
            if (isNum && num > 0 && num <= toolbarSlots) 
            {
                Debug.Log("got num press");
                ChangeSelectedSlot(num-1);
            }
        }
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = slots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item =  itemInSlot.item;
            // if (use)
            // {
            //     itemInSlot.count--;
            //     if (itemInSlot.count <= 0)
            //     {
            //         Destroy(itemInSlot.gameObject);
            //     }
            //     else
            //     {
            //         itemInSlot.refreshCount();
            //     }
            //     return item;
            // }
        }
        return null;
    }


    public void ChangeSelectedSlot(int newValue)
    {
        Debug.Log("changing");
        if (selectedSlot >= 0) 
        { 
            slots[selectedSlot].Deselect(); 
        }
        
        slots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        // for (int i = 0; i < slots.Length; i++)
        // {
        //     InventorySlot slot = slots[i];
        //     InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        //     if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < item.maxStack && item.stackable)
        //     {
        //         itemInSlot.count++;
        //         itemInSlot.refreshCount();
        //         return true;
        //     }
        // }
        
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                Debug.Log("Yay!");
                return true;
            }
        }
        return false;
    }


    void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(invItemPrefab, slot.transform);
        InventoryItem invItem = newItem.GetComponent<InventoryItem>();
        invItem.InitItem(item);
    }
}