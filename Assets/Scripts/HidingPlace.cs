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
        StartCoroutine(KeyDelay());
        FPSCamera.Instance.SwitchToAlternativeCam(_hideCam);
        FPSCamera.Instance.DisableInput();
        FPSController.Instance.DisableInput();
        InteractUI.Instance.Show("Exit hiding");
    }

    public void ExitHiding()
    {
        _hiding = false;
        FPSCamera.Instance.SwitchToFPSCam();
        FPSCamera.Instance.EnableInput();
        FPSController.Instance.EnableInput();
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
