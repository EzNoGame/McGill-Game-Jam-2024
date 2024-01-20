using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour
{

    public Image image;
    public Text countText;

    public Item item;
    public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.img;
        transform.localScale = new Vector2(0.6f, 0.6f);
        //refreshCount();
    }

    // public void refreshCount()
    // {
    //     countText.text = count.ToString();
    //     bool textActive = count > 1;
    //     countText.gameObject.SetActive(textActive);
    // }

   
}