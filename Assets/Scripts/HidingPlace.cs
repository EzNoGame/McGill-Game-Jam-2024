using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour, IInteractable
{
    [SerializeField] Camera _hideCam;

    void Awake()
    {
        _hideCam.enabled = false;
    }

    public void Interact()
    {
        Debug.Log("You hid!");
        FPSCamera.Instance.SwitchToAlternativeCam(_hideCam);
    }

    public string GetDisplayText()
    {
        return "Hide";
    }
}
