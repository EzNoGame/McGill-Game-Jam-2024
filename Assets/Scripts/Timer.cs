using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float _timeLeft;
    private float _maxTime = 305;
    private bool _timerOn;

    public Image Vignette;
    public TextMeshProUGUI _timerText;

    void Awake()
    {
        Activate();
        Color color = Vignette.color;
        color.a = 0f;
        Vignette.color = color;
    }

    public void Activate()
    {
        _timerOn = true;
        _timeLeft = _maxTime;
    }

    private void Update()
    {
        if (!_timerOn) return;

        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            Refresh();
            if (_timeLeft <= 300f) ChangeAlpha();
        }
        else
        {
            Debug.Log("Time up!");
            _timeLeft = 0;
            _timerOn = false;
        }
    }

    private void Refresh()
    {
        int mins = Mathf.FloorToInt(_timeLeft / 60);
        int secs = Mathf.FloorToInt(_timeLeft % 60);
        string minsString = mins <= 9 ? "0" + mins.ToString() : mins.ToString();
        string secsString = secs <= 9 ? "0" + secs.ToString() : secs.ToString();
        _timerText.text = minsString + " : " + secsString;
    }

    private void ChangeAlpha()
    {
        Color color = Vignette.color;
        color.a = (300f - _timeLeft) / 300f;
        Vignette.color = color;
    }
}
