using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintUI : Singleton<SprintUI>
{
    public Image _fill;

    public void Refresh(float factor)
    {
        _fill.fillAmount = factor;
    }
}
