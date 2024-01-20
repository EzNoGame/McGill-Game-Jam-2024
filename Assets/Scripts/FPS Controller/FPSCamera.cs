using System;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class FPSCamera : Singleton<FPSCamera> {
    [SerializeField]
    private float _sensitivity = 100f;

    // [SerializeField, Header("transform in player to sync the rotation with camera")]
    // private Transform _orientation;
    
    // [SerializeField, Header("transform in player to keep track the pos of camera")]
    // private Transform _cameraHolder;

    // [SerializeField, Header("simulate of players hand")]
    // private Transform _hand;

    private float _xRotation, _yRotation;

    public GameObject _objLookingAt;

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
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
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

        float mosueX = Input.GetAxisRaw("Mouse X") * _sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _sensitivity;

        _xRotation -= mouseY;
        _xRotation = Math.Clamp(_xRotation, -90f, 90f);
        _yRotation += mosueX;

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        //_orientation.rotation = Quaternion.Euler(0, _yRotation, 0);

        //transform.position = _cameraHolder.transform.position;

        float distance = 3f;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, 1<<6))
        {
            distance = hit.distance;
        }
        
        //_hand.position = transform.position + transform.TransformDirection(Vector3.forward) * distance;

    }

    public GameObject GetObjLookedAt()
    {
        return _objLookingAt;
    }

    public void SwitchToAlternativeCam(Camera alt)
    {
        otherCam = alt;
        thisCam.enabled = false;
        otherCam.enabled = true;
    }

    public void SwitchToFPSCam()
    {
        otherCam.enabled = false;
        thisCam.enabled = true;
        otherCam = null;
    }

    public void EnableInput() { _controlEnabled = true; }

    public void DisableInput() { _controlEnabled = false; } 
}