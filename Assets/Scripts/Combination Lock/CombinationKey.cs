using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationKey : MonoBehaviour, IInteractable
{

    [SerializeField, Range(0,9)]
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
