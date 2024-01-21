using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : Singleton<CameraSystem>
{
    
    [SerializeField] float _sensitivity = 10f;

    private float _xRotation, _yRotation;

    public GameObject _objLookingAt;

    public Transform _orientation;

    [SerializeField] Camera _currentCam;
    private Camera thisCam;
    private Camera otherCam;

    private bool _controlEnabled;

    private void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        thisCam = GetComponent<Camera>();
        _controlEnabled = true;
    }
    
    private void FixedUpdate() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, 1<<6))
        {
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            if (_objLookingAt == hit.collider.gameObject) return;
            
            _objLookingAt = hit.collider.gameObject;
        }
        else
        {
            _objLookingAt = null;
        }
    }

    private void LateUpdate() 
    {
        if (!_controlEnabled) return;
        
        float mouseX = Input.GetAxisRaw("Mouse X") * _sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _sensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        _yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);

        float distance = 3f;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, 1<<6))
        {
            distance = hit.distance;
        }
    }

    public GameObject GetObjLookedAt()
    {
        return _objLookingAt;
    }

    public void SwitchToAlternativeCam(Camera alt)
    {
        FPSController.Instance.DisableInput();
        this.DisableInput();

        otherCam = alt;
        thisCam.enabled = false;
        otherCam.enabled = true;
        _currentCam = otherCam;
    }

    public void SwitchToFPSCam()
    {
        otherCam.enabled = false;
        thisCam.enabled = true;
        //otherCam = null;
        _currentCam = thisCam;

        Debug.Log("heeeeere");


        FPSController.Instance.EnableInput();
        this.EnableInput();
    }

    public void EnableInput() { _controlEnabled = true; }

    public void DisableInput() { _controlEnabled = false; } 
}
