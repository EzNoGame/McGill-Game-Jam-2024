using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem  : Singleton<AudioSystem>
{
    private float _mainVolume = 1;
    private float _sfxVolume = 1;
    private float _bgmVolume = 1;
    private bool _isCrossfading = true;
    private int _crossFadeCounter = 0;
    private float _crossFadeTimer = 0;

    [SerializeField]
    private List<AudioSource> audioSources;

    public float fadeDuration = 2.0f; // Duration of the crossfade in seconds

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

    private void Start()
    {
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        audioSources[_crossFadeCounter].volume = _mainVolume*_bgmVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if(clip != null)
        {
            audioSources[_crossFadeCounter].PlayOneShot(clip, _mainVolume*_sfxVolume);
        }
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        if(clip != null)
            audioSources[_crossFadeCounter].PlayOneShot(clip, volume*_mainVolume*_sfxVolume);
    }

    private void Update() {
        if(_isCrossfading)
        {
            _crossFadeTimer += Time.deltaTime;
            if(_crossFadeTimer > fadeDuration)
            {
                _crossFadeTimer = 0;
                _isCrossfading = false;
            }
            else
            {
                audioSources[_crossFadeCounter].volume = _crossFadeTimer / fadeDuration;
                audioSources[(_crossFadeCounter+1)%audioSources.Count].volume = (fadeDuration - _crossFadeTimer) / fadeDuration;
            }
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        _crossFadeCounter = (_crossFadeCounter+1)%audioSources.Count;
        audioSources[_crossFadeCounter].clip = clip;
        audioSources[_crossFadeCounter].Play();
        _isCrossfading = true;
    }
}