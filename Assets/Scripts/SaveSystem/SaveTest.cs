using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    private int counter = 0;

    public void AddPuzzle()
    {
        SaveSystem.Instance.AddPuzzle(counter);
        counter++;
    }

    public void Reset()
    {
        SaveSystem.Instance.NewRun();
        counter = 0;
    }

    public void Display()
    {
        GetComponentInChildren<TMP_Text>().text = SaveSystem.Instance.GetLastPuzzle().ToString();
    }
}
