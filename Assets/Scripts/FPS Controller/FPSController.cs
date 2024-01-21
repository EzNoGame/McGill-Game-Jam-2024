using System;
using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;

[RequireComponent(typeof(CharacterController), typeof(Rigidbody))]
public class FPSController : Singleton<FPSController>
{
    [SerializeField]
    private float _walkSpeed = 5f, _sprintSpeed = 9f;
    [SerializeField, Header("in second, how many time can player still jump after leaving a platform")]
    private float _accThreshold = 0.7f;
    [SerializeField]
    private Transform _orientation;

    

    

    public GameObject Model;
    private MeshRenderer _mesh;


    private Vector3 _horizontalInput;
    private CharacterController _cc;
    private float _verticalVelocity = -9.8f;
    private Vector3 _movement;


    private bool _controlEnabled;
    public bool IsHiding;
    [SerializeField] float _stamina = 100f;
    [SerializeField] float _rechargeRate = 10f;
    [SerializeField] float _drainRate = 25f;
    [SerializeField] bool _isSprinting;
    [SerializeField] bool _lockSprint;


    public float HorizontalMaxSpeed => _walkSpeed;

    [SerializeField] AudioSource running;
    [SerializeField] AudioSource panting;
    [SerializeField] AudioSource hiding;


    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _horizontalInput = new Vector3(0f, 0f, 0f);

        _verticalVelocity = -9.8f;
        _movement = Vector3.zero;

        _controlEnabled = true;

        _isSprinting = false;
        _lockSprint = false;

        IsHiding = false;

        _mesh = Model.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        HandleInput();

        if (Input.GetKey(KeyCode.LeftShift) && _stamina > 0 && !_lockSprint && _horizontalInput.magnitude > 0.1f)
        {
            _stamina = Mathf.Clamp(_stamina - (_drainRate * Time.deltaTime), 0, 100);
            _isSprinting = true;
        }
        else
        {
            _stamina = Mathf.Clamp(_stamina + (_rechargeRate * Time.deltaTime), 0, 100);
            _isSprinting = false;
        }

        if (_stamina <= 0.1f && !_lockSprint) StartCoroutine(LockSprint());

        SprintUI.Instance.Refresh((float) (_stamina / 100f));

        if (!_controlEnabled) return;

        CalculateMovement();
        _cc.Move(_movement * Time.deltaTime);

        running.enabled = _isSprinting;
        
        panting.enabled =  _lockSprint || _stamina < 50 && !_isSprinting;
        
        hiding.enabled = IsHiding;
        
       
    }

    Vector2 VerticalInputThreashHold()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(Mathf.Abs(x) <= _accThreshold)
            x = 0;
        
        if(Mathf.Abs(y) <= _accThreshold)
            y = 0;

        return new Vector2(x, y);
    }
    void HandleInput()
    {
        Vector2 input = VerticalInputThreashHold();
        _horizontalInput = input.x * _orientation.right +  input.y * _orientation.forward;
    }


    void CalculateMovement()
    {
        _movement = new Vector3(
            _horizontalInput.x*(_isSprinting?_sprintSpeed:_walkSpeed), 
            _verticalVelocity, 
            _horizontalInput.z*(_isSprinting?_sprintSpeed:_walkSpeed));

    }

    IEnumerator LockSprint()
    {
        _lockSprint = true;
        yield return new WaitForSeconds(3f);
        _lockSprint = false;
    }

    public void EnableInput() { _controlEnabled = true; }

    public void DisableInput() { _controlEnabled = false; } 

    public void ShowMesh() { _mesh.enabled = true; }
    public void HideMesh() { _mesh.enabled = false; }
}
