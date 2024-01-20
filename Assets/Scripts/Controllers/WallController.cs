using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public void OpenWall() {
        this.transform.Translate(Vector3.up*Time.deltaTime*3, Space.World);
    }
    
}
