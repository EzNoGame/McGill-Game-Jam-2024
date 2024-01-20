using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction.z = player.eulerAngles.y;
        transform.localEulerAngles = direction;
    }
}
