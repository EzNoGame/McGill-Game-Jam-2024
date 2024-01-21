using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float lvl) {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(lvl)*20f);
    }

    public void SetSoundFXVolume(float lvl) {
        audioMixer.SetFloat("SoundFX", Mathf.Log10(lvl)*20f);
    }

    public void SetBackroundMusicVolume(float lvl) {
        audioMixer.SetFloat("BackgroundMusic", Mathf.Log10(lvl)*20f);
    }
}
