using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private GearSize _inputGearSize = GearSize.NotAGear;

    [SerializeField]
    private GameObject smallGear, mediumGear, largeGear;

    private int _bruteForceCounter = 0;
    private bool _broken = false;

    public void OnEnable()
    {
        BroadcastSystem.PickupGear += RemoveGear;
    }

    public void OnDisable()
    {
        BroadcastSystem.PickupGear -= RemoveGear;
    }

    public string GetDisplayText()
    {
        if(_inputGearSize != GearSize.NotAGear)
        {
            return "";
        }

        return "Press E to insert gear";
    }

    public void Interact()
    {
        if(_inputGearSize != GearSize.NotAGear)
        {
            return;
        }

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
                    gear = Instantiate(smallGear, transform.position + transform.forward * (-0.5f), Quaternion.identity);
                    break;
                case GearSize.Medium:
                    gear = Instantiate(mediumGear, transform.position + transform.forward * (-0.5f), Quaternion.identity);
                    break;
                case GearSize.Large:
                    gear = Instantiate(largeGear, transform.position + transform.forward * (-0.5f), Quaternion.identity);
                    break;
            }

            gear.transform.parent = transform;
            gear.GetComponent<PickUp>().ToggleInteractability();

            BroadcastSystem.GearInstalled?.Invoke(_inputGearSize, transform.parent.gameObject);
        }
        else
        {
            if(item.type == ItemType.Brick)
                _bruteForceCounter++;

            if(_bruteForceCounter >= 10)
            {
                transform.parent.GetComponent<Puzzle>().Solved();
            }
        }
    }

    public bool Match()
    {
        if(_broken)
            return true;

        return _inputGearSize == _gearSize;
    }

    public void RemoveGear(GameObject g)
    {
        if(!object.ReferenceEquals(g, gameObject))
        {
            return;
        }

        Debug.Log("remove gear");

        _inputGearSize = GearSize.NotAGear;
    }

    public GearSize GetInputSize() => _inputGearSize;
}
