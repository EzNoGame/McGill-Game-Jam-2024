using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WingScript : MonoBehaviour
{

    public Logic logic;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider coll) {
        Debug.Log("collide");
        logic.win();
    }
}
