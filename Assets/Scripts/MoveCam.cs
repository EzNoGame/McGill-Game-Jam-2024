using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform CameraPos;

    private void Update()
    {
        transform.position = CameraPos.position;
        Debug.Log(transform.position);
    }
}
