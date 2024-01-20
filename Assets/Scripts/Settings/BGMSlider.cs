using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSlider : MonoBehaviour 
{
    public void OnChangeBGMVolume()
    {
        float value = GetComponent<UnityEngine.UI.Slider>().value;
        AudioSystem.Instance.SetBGMVolume(value);
    }
}
