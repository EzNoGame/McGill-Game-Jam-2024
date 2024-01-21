using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    [SerializeField] string _name;
    [SerializeField] Item _item;

    [SerializeField] bool _interactable = true;
     
    AudioClip pickUpClip = null;
    
    public void Start() {
        pickUpClip = Resources.Load<AudioClip>("AudioClips/Pick_up_item");

    }
    public void Interact()
    {
        if (!_interactable)
            return;

        if (InventoryManager.Instance.AddItem(_item))
        {
            if (pickUpClip != null) {
            SoundFXManager.instance.PlaySoundFX(pickUpClip, transform, 1f); }

            if(transform.parent != null)
            {
                BroadcastSystem.PickupGear?.Invoke(transform.parent.gameObject);
            }
            // TODO SHOW ITEM IN HAND
            transform.localPosition = Vector3.zero;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponentInChildren<Collider>().enabled = false;
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
