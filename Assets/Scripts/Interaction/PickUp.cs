using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    [SerializeField] string _name;
    [SerializeField] Item _item;

    [SerializeField] bool _interactable = true;

    public void Interact()
    {
        if (!_interactable)
            return;

        if (InventoryManager.Instance.AddItem(_item))
        {
            if(transform.parent != null)
            {
                BroadcastSystem.PickupGear?.Invoke(transform.parent.gameObject);
            }
            // TODO SHOW ITEM IN HAND
            transform.localPosition = Vector3.zero;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public string GetDisplayText()
    {
        if (!_interactable)
            return "";

        return $"Pick up {_name}";
    }

    public void ToggleInteractability()
    {
        _interactable = !_interactable;
    }
}
