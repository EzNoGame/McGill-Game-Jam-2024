using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    // Some keyboard E icon

    private bool visible; // Prevents every frame calling Show() and Hide()

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        GameObject target = FPSCamera.Instance.GetObjLookedAt();
        IInteractable component = target.GetComponent<IInteractable>();
        if (component == null && visible)
        {
            Hide();
            return;
        }

        _text.text = component.GetDisplayText();
        if (!visible) Show();
    }

    void Show()
    {
        visible = true;
        _text.enabled = true;
    }

    void Hide()
    {
        visible = false;
        _text.enabled = false;
    }
}
