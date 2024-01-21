using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    public float volume;
    [SerializeField] private AudioSource soundFXObj;
    [SerializeField] private float spread = 10;
    [SerializeField] private float doppler = 4;

    // Start is called before the first frame update
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlaySoundFX(AudioClip audioClip, Transform spawn, float volume) {
        AudioSource audioSource = Instantiate(soundFXObj, spawn.position, Quaternion.identity);
        audioSource.spread = spread;
        audioSource.dopplerLevel = doppler;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
