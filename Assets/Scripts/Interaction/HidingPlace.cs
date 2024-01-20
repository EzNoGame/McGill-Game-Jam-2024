using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour, IInteractable
{
    [SerializeField] Camera _hideCam;
    private bool _canExit;
    private bool _hiding;

    void Awake()
    {
        _hideCam.enabled = false;
        _hiding = false;
        _canExit = false;
    }

    void Update()
    {
        if (_hiding && _canExit && Input.GetKeyDown("e"))
        {
            ExitHiding();
        }
    }

    public void Interact()
    {
        if (!_hiding) EnterHiding();
    }

    public void EnterHiding()
    {
        _hiding = true;
        InteractScript.Instance.Override();
        StartCoroutine(KeyDelay());
        CameraSystem.Instance.SwitchToAlternativeCam(_hideCam);
        CameraSystem.Instance.DisableInput();
        FPSController.Instance.DisableInput();
        FPSController.Instance.IsHiding = true;
        InteractUI.Instance.Show("Exit hiding");
    }

    public void ExitHiding()
    {
        _hiding = false;
        InteractScript.Instance.UnOverride();
        CameraSystem.Instance.SwitchToFPSCam();
        CameraSystem.Instance.EnableInput();
        FPSController.Instance.EnableInput();
        FPSController.Instance.IsHiding = false;
    }

    public string GetDisplayText()
    {
        return "Hide";
    }

    IEnumerator KeyDelay()
    {
        float elapsed = 0f;
        _canExit = false;
        while (elapsed < 0.1f)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        _canExit = true;
    }
}