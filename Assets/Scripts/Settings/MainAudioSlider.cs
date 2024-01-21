using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioSlider : MonoBehaviour
{
    public SoundMixerManager mixer;

    public void OnChangeMainVolume()
    {
        float value = GameObject.Find("MainVol").GetComponent<UnityEngine.UI.Slider>().value;
        mixer.SetMasterVolume(value);
    }

    public void OnChangeBackgroundVolume()
    {
        float value = GameObject.Find("BackgroundVol").GetComponent<UnityEngine.UI.Slider>().value;
        mixer.SetBackroundMusicVolume(value);
    }
    public void OnChangeSFXVolume()
    {
        float value = GameObject.Find("SFXVol").GetComponent<UnityEngine.UI.Slider>().value;
        mixer.SetSoundFXVolume(value);
    }
}
