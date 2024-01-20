using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationKey : IInteractable
{

    [SerializeField, Range(1,9)]
    private int _keyValue;

    public string GetDisplayText()
    {
        return "Press E to Input";
    }

    public void Interact()
    {
        BroadcastSystem.KeyPressed(_keyValue);
    }
}
