using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem  : Singleton<AudioSystem>
{
    private float _mainVolume = 1;
    private float _sfxVolume = 1;
    private float _bgmVolume = 1;
    private AudioSource audioSource;

    public void SetMainVolume(float volume)
    {
        _mainVolume = volume;
        UpdateVolume();
    }

    public void SetSFXVolume(float volume)
    {
        _sfxVolume = volume;
        UpdateVolume();
    }

    public void SetBGMVolume(float volume)
    {
        _bgmVolume = volume;
        UpdateVolume();
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        audioSource.volume = _mainVolume*_bgmVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if(clip != null)
        {
            Debug.Log("Playing SFX");
            audioSource.PlayOneShot(clip, _mainVolume*_sfxVolume);
        }
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        if(clip != null)
            audioSource.PlayOneShot(clip, volume*_mainVolume*_sfxVolume);
    }
    public void PlayBGM(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = true;
    }
}