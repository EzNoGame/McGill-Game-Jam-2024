using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    [SerializeField] string _name;
    [SerializeField] Item _item;

    public void Interact()
    {
        Debug.Log("You interacted");
        if (InventoryManager.Instance.AddItem(_item))
        {
            // TODO SHOW ITEM IN HAND
            transform.SetParent(CameraSystem.Instance.Hand);
            transform.localPosition = Vector3.zero;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public string GetDisplayText()
    {
        return $"Pick up {_name}";
    }
}
