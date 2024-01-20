using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    private TMP_Text _text;

    public void OnEnable()
    {
        BroadcastSystem.BroadcastMessage += RecieveMessage;
    }

    public void OnDisable()
    {
        BroadcastSystem.BroadcastMessage -= RecieveMessage;
    }

    public void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void RecieveMessage(string message)
    {
        _text.text = message;
    }
}
