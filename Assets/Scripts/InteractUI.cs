using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractUI : Singleton<InteractUI>
{
    public TextMeshProUGUI _text;
    public Image _base;
    // Some keyboard E icon

    void Awake()
    {
        _instance = this;
        _text.enabled = false;
        _base.enabled = false;
    }

    public void Show(string pText)
    {
        _text.text = pText;
        _text.enabled = true;
        _base.enabled = true;
    }

    public void Hide()
    {
        _text.enabled = false;
        _base.enabled = false;
    }
}
