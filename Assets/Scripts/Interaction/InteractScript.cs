using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : Singleton<InteractScript>
{
    private bool _isOverridden;

    void Update()
    {
        if (_isOverridden) return;

        GameObject target = CameraSystem.Instance.GetObjLookedAt();
        if (target == null)
        {
            InteractUI.Instance.Hide();
            return;
        }
        
        IInteractable interactComponent = target.GetComponent<IInteractable>();
        if (interactComponent == null)
        {
            InteractUI.Instance.Hide();
            return;
        }

        InteractUI.Instance.Show(interactComponent.GetDisplayText());

        if (Input.GetKeyDown("e"))
        {
            interactComponent.Interact();
        }
    }

    public void Override()
    {
        _isOverridden = true;
    }

    public void UnOverride()
    {
        _isOverridden = false;
    }
}
