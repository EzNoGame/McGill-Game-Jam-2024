using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GearSize
{
    Small,
    Medium,
    Large,
    NotAGear,
}

public class GearKnob : IInteractable
{
    [SerializeField]
    private GearSize _gearSize;

    private GearSize _inputGearSize;

    private int _bruteForceCounter = 0;

    public string GetDisplayText()
    {
        return "Press E to insert gear";
    }

    public void Interact()
    {
        Item item = InventoryManager.Instance.GetSelectedItem();
        if(item.type == ItemType.Gear)
        {
            _inputGearSize = item.gearSize;
        }
        else
        {
            _bruteForceCounter++;//TODO: 
        }
    }

    public bool Match()
    {
        return _inputGearSize == _gearSize;
    }
}
