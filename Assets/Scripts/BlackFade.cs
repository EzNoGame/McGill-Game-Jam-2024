using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BlackFade : MonoBehaviour
{
    private float _elapsed;
    private Image _black;
    private Color _baseBlack = new Color(0, 0, 0, 0);
    private bool _fading;

    private void Awake()
    {
        _black = GetComponent<Image>();
        _fading = false;
    }

    public IEnumerator FadeToBlack(float duration)
    {
        if (_fading) yield break;
        _fading = true;
        _elapsed = 0f;
        while (_elapsed < duration)
        {
            Color color = _baseBlack;
            color.a = (float) (_elapsed / duration);
            _black.color = color;
            _elapsed += Time.deltaTime;
            yield return null;
        }

        _black.color = _baseBlack;
        _fading = false;
    }

    public IEnumerator FadeFromBlack(float duration)
    {
        if (_fading) yield break;
        _fading = true;
        _elapsed = 0f;
        while (_elapsed < duration)
        {
            Color color = _baseBlack;
            color.a = (float) (1f - (_elapsed / duration));
            _black.color = color;
            _elapsed += Time.deltaTime;
            yield return null;
        }
        _fading = false;
    }
}
