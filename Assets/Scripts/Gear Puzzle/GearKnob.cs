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

public class GearKnob : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GearSize _gearSize;

    private GearSize _inputGearSize;

    [SerializeField]
    private GameObject smallGear, mediumGear, largeGear;

    private int _bruteForceCounter = 0;

    public string GetDisplayText()
    {
        return "Press E to insert gear";
    }

    public void Interact()
    {
        Item item = InventoryManager.Instance.GetSelectedItem();

        if(item == null)
        {
            return;
        }

        if(item.type == ItemType.Gear)
        {
            _inputGearSize = item.gearSize;
            InventoryManager.Instance.DeleteSelectedItem();
            GameObject gear = null;

            switch (item.gearSize)
            {
                case GearSize.Small:
                    gear = Instantiate(smallGear, transform.position, Quaternion.identity);
                    break;
                case GearSize.Medium:
                    gear = Instantiate(mediumGear, transform.position, Quaternion.identity);
                    break;
                case GearSize.Large:
                    gear = Instantiate(largeGear, transform.position, Quaternion.identity);
                    break;
            }

            gear.transform.localRotation = Quaternion.Euler(90, 0, 0);
            gear.transform.parent = transform;
            gear.GetComponent<PickUp>().ToggleInteractability();

            BroadcastSystem.GearInstalled?.Invoke(_inputGearSize, transform.parent.gameObject);
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
