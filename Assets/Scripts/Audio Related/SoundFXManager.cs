using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    public float volume;
    [SerializeField] private AudioSource soundFXObj;

    // Start is called before the first frame update
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlaySoundFX(AudioClip audioClip, Transform spawn, float volume) {
        AudioSource audioSource = Instantiate(soundFXObj, spawn.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
