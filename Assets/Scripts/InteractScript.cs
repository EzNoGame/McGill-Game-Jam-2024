using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    void Update()
    {
        GameObject target = FPSCamera.Instance.GetObjLookedAt();
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
}
