using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] pickup;

    public void PickupItem(int id)
    {
        bool added = inventoryManager.AddItem(pickup[id]);
        if (added)
        {
            Debug.Log("added");
        }
        else
        {
            Debug.Log("inv full");
        }
    }

}

