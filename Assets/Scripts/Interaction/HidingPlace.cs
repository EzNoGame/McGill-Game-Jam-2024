using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingPlace : MonoBehaviour, IInteractable
{
    [SerializeField] Camera _hideCam;
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
            Debug.Log("YESYESYES");
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
        CameraSystem.Instance.SwitchToAlternativeCam(_hideCam);
        FPSController.Instance.IsHiding = true;
        FPSController.Instance.HideMesh();
        InteractUI.Instance.Show("Exit hiding");
    }

    public void ExitHiding()
    {
        _hiding = false;
        Debug.Log("1");
        InteractScript.Instance.UnOverride();
        Debug.Log("2");
        CameraSystem.Instance.SwitchToFPSCam();
        Debug.Log("3");
        FPSController.Instance.IsHiding = false;
        Debug.Log("4");
        FPSController.Instance.ShowMesh();
        Debug.Log("5");
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
