using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : Singleton<InteractUI>
{
    private TextMeshPro _text;
    private MeshRenderer _mesh;
    // Some keyboard E icon

    void Awake()
    {
        _text = GetComponent<TextMeshPro>();
        _mesh = GetComponent<MeshRenderer>();
        _mesh.enabled = false;
    }

    public void Show(string pText)
    {
        _text.text = pText;
        _mesh.enabled = true;
    }

    public void Hide()
    {
        _mesh.enabled = false;
    }
}
