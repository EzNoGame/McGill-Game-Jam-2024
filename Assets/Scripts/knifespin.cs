using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class knifespin : MonoBehaviour
{
    public GameObject knife;
    private Image _image;
    private Animator _anim;
    public AudioSource audio;


    private void Awake()
    {
        _image = knife.GetComponent<Image>();
        _anim = knife.GetComponent<Animator>();
        _image.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            FPSController.Instance.CSMode();
            if (!audio.isPlaying) audio.Play(0);
            _anim.ResetTrigger("pressF");
            _anim.SetTrigger("pressF");
            _image.enabled = true;
            _anim.Play("knifespin");
        }
    }

}
