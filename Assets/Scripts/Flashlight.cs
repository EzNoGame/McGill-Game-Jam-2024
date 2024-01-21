using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Vector3 _offset;
    public Transform _followCam;
    public Transform _followOrient;
    [SerializeField] float _speed;

    void Awake()
    {
        _offset = transform.position - _followCam.position;
    }

    void Update()
    {
        transform.position = _followCam.position + _offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, _followCam.rotation, _speed * Time.deltaTime);
    }
}
