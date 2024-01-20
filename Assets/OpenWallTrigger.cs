using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class OpenWallTrigger : MonoBehaviour
{
    public WallController targetWall;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        targetWall.OpenWall();
    }
}
