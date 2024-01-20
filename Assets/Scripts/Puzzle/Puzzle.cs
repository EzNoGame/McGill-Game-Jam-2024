using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField]
    private int ID;
    protected bool _solved = false;
    public UnityEvent onPuzzleSolved;
    public int GetID() => ID;

    protected virtual void Solved()
    {
        SaveSystem.Instance.AddPuzzle(ID);
        Debug.Log("solved");
        onPuzzleSolved?.Invoke();
        _solved = true;
        BroadcastSystem.PuzzleSolved?.Invoke(this);
    }


}
