using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLockLight : MonoBehaviour
{
    private bool _on;
    public Material _onMaterial;

    public void TurnOn()
    {
        GetComponent<Light>().enabled = true;
        GetComponent<Light>().color = Color.blue;
    }
}