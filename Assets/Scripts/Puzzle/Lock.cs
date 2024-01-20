using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Puzzle, IInteractable
{
    private string _displayText;

    void Awake()
    {
        _displayText = "Unlock";
    }

    public void Interact()
    {
        if (InventoryManager.Instance.GetSelectedItem().type == ItemType.Key)
        {
            Solved();
        }
        else
        {
            _displayText = "Unlock (requires key)";
        }
    }

    public string GetDisplayText()
    {
        return _displayText;
    }
}
