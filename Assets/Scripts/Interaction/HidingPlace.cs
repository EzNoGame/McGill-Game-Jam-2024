using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingPlace : MonoBehaviour, IInteractable
{
    [SerializeField] Camera _hideCam;
    [SerializeField] Transform _camPos;
    private Camera _mainCam;
    private bool _canExit;
    private bool _hiding;
    public Image Icon;

    void Awake()
    {
        _hideCam.enabled = false;
        _hiding = false;
        _canExit = false;
        _mainCam = Camera.main;
    }

    void Update()
    {
        if (_hiding && _canExit && Input.GetKeyDown("e"))
        {
            ExitHiding();
        }

        Icon.transform.rotation = Quaternion.LookRotation(Icon.transform.position - _mainCam.transform.position);
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
        CameraSystem.Instance.SwitchToAlternativeCam(_camPos);
        FPSController.Instance.IsHiding = true;
        FPSController.Instance.HideMesh();
        InteractUI.Instance.Show("Exit hiding");
    }

    public void ExitHiding()
    {
        _hiding = false;
        InteractScript.Instance.UnOverride();
        CameraSystem.Instance.SwitchToFPSCam();
        FPSController.Instance.IsHiding = false;
        FPSController.Instance.ShowMesh();
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
