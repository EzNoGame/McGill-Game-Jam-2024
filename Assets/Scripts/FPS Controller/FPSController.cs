using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Rigidbody))]
public class FPSController : Singleton<FPSController>
{
    [SerializeField]
    private float _walkSpeed = 5f, _sprintSpeed = 10f;
    [SerializeField, Header("in second, how many time can player still jump after leaving a platform")]
    private float _accThreshold = 0.7f;
    [SerializeField]
    private Transform _orientation;

    private Vector3 _horizontalInput;
    private CharacterController _cc;
    private float _verticalVelocity = -9.8f;
    private Vector3 _movement;


    private bool _controlEnabled;

    public float HorizontalMaxSpeed => _walkSpeed;


    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _horizontalInput = new Vector3(0f, 0f, 0f);

        _verticalVelocity = -9.8f;
        _movement = Vector3.zero;

        _controlEnabled = true;
    }

    void Update()
    {
        if (!_controlEnabled) return;

        HandleInput();
        CalculateMovement();
        _cc.Move(_movement * Time.deltaTime);
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

    bool SprintCheck()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    void CalculateMovement()
    {

        bool isSprinting = SprintCheck();

        _movement = new Vector3(
            _horizontalInput.x*(isSprinting?_sprintSpeed:_walkSpeed), 
            _verticalVelocity, 
            _horizontalInput.z*(isSprinting?_sprintSpeed:_walkSpeed));

    }

    public void EnableInput() { _controlEnabled = true; }

    public void DisableInput() 
    { 
        //_movement = Vector3.zero;
        _controlEnabled = false; 
    } 
}
