using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSlider : MonoBehaviour 
{

    public SoundMixerManager mixer;
    public void OnChangeBGMVolume()
    {
        float value = GameObject.Find("Main").GetComponent<UnityEngine.UI.Slider>().value;
        mixer.SetMasterVolume(value);
    }
}
