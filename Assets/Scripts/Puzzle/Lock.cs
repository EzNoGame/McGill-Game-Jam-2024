using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Puzzle, IInteractable
{
    public void Interact()
    {
        if (InventoryManager.Instance.GetSelectedItem())
        {
            
        }
    }

    public string GetDisplayText()
    {
        return "Unlock";
    }
}
