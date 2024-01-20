using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSlider : MonoBehaviour
{
    public void OnChangeSFXVolume()
    {
        float value = GetComponent<UnityEngine.UI.Slider>().value;
        AudioSystem.Instance.SetSFXVolume(value);
    }
}
