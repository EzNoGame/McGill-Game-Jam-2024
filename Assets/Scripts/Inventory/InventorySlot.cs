using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image img;
    public Color selected;
    public Color notSelected;


    public void Awake()
    {
        img.color = notSelected;
    }

    public void Select()
    {
        img.color = selected;
    }
    public void Deselect()
    {
        img.color = notSelected;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) 
        { 
            GameObject dropped = eventData.pointerDrag;
            InventoryItem dragItem = dropped.GetComponent<InventoryItem>();
            dragItem.parentAfterDrag = transform; 
        }
    }

}