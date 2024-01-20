using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    private static InteractUI _instance;
    public static InteractUI Instance { get { return _instance; } }

    private TextMeshProUGUI _text;
    //private MeshRenderer _mesh;
    // Some keyboard E icon

    void Awake()
    {
        _instance = this;
        _text = GetComponent<TextMeshProUGUI>();
        //_mesh = GetComponent<MeshRenderer>();
        //_mesh.enabled = false;
        _text.enabled = false;
    }

    public void Show(string pText)
    {
        _text.text = pText;
        //_mesh.enabled = true;
        _text.enabled = true;
    }

    public void Hide()
    {
        //_mesh.enabled = false;
        _text.enabled = false;
    }
}
