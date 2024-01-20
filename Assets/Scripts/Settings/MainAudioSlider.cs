using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioSlider : MonoBehaviour
{
    public void OnChangeMainVolume()
    {
        float value = GetComponent<UnityEngine.UI.Slider>().value;
        AudioSystem.Instance.SetMainVolume(value);
    }
}
