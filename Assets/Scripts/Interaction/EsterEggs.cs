using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsterEggs : MonoBehaviour
{
    [SerializeField]
    private Item _brick;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.Instance.AddItem(_brick);
        }
    }
}
