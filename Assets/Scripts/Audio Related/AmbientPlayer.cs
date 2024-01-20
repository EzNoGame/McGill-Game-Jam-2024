using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmbientPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip _ambient, _clockTicking;

    private float _randomTimer, _timer;

    public void Start()
    {
        _randomTimer = Random.Range(10, 30);
        _timer = 0;
        AudioSystem.Instance.PlayBGM(_ambient);
    }

    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _randomTimer)
        {
            _timer = 0;
            _randomTimer = Random.Range(10, 30);
            AudioSystem.Instance.PlayBGM(_clockTicking);
        }
    }
}
