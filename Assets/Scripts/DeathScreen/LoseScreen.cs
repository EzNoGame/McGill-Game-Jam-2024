using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    private AudioClip Aur_Aur_Aur;

    public void Start()
    {
        SoundFXManager.instance.PlaySoundFX(Aur_Aur_Aur, transform, 1f);
    }
}
