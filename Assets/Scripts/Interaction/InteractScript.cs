using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : Singleton<InteractScript>
{
    private bool _isOverridden;
    private IInteractable _currentInteractable;
    public IInteractable Current { get { return _currentInteractable; } }

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

        _currentInteractable = interactComponent;
        InteractUI.Instance.Show(_currentInteractable.GetDisplayText());

        if (Input.GetKeyDown("e"))
        {
            _currentInteractable.Interact();
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
