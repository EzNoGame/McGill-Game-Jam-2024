using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Puzzle, IInteractable
{
    private string _displayText;

    private int _bruteForceCounter = 0;

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
        else if(InventoryManager.Instance.GetSelectedItem().type == ItemType.Brick)
        {
            _bruteForceCounter++;
            if(_bruteForceCounter >= 10)
            {
                Solved();
            }
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
