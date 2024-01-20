using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField]
    private int ID;

    public int GetID() => ID;

    protected virtual void Solved()
    {
        SaveSystem.Instance.AddPuzzle(ID);
    }
}
