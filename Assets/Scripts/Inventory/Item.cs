using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public TileBase tile;
    public Sprite img;
    public bool stackable = true;
    public int maxStack;
    public ItemType type;

    public GearSize gearSize;
    //public ActionType action;
    //public Vector2Int range = new Vector2Int(5,4);
}

public enum ItemType
{
    Gear,
    Key,
    Brick,
}