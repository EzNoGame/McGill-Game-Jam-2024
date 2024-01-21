using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public enum Sequence
{
    VIDEO,
    LOOP,
    FALL
}

public class IntroElevator : MonoBehaviour
{
    [SerializeField] VideoPlayer _player;
    [SerializeField] RawImage _image;
    [SerializeField] BlackFade _fade;
    private Sequence _sequence;

    void Awake()
    {
        _sequence = Sequence.LOOP;
    }

    private void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            StartCoroutine(Enter());
        }

        if (Input.GetKeyDown("i"))
        {
            StartCoroutine(Fall());
        }
    }

    public IEnumerator Enter()
    {
        _player.Prepare();
        while (!_player.isPrepared)
        {
            yield return null;
        }
        Debug.Log("Ready");
        _image.texture = _player.texture;
        _player.Play();
        _player.isLooping = true;

        StartCoroutine(_fade.FadeFromBlack(2f));

        StartCoroutine(CameraShake.Instance.BeginBounce(10f));

        yield return null;
    }

    public IEnumerator Loop()
    {
        yield break;
    }

    public IEnumerator Fall()
    {
        CameraShake.Instance.EndBounce();
        float elapsed = 0f;
        float duration = 2.5f;
        float maxSpeed = 10f;

        while (elapsed < duration)
        {
            float factor = elapsed / duration;
            _player.playbackSpeed = Mathf.Lerp(1, maxSpeed, factor);
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        _player.playbackSpeed = 0f;
        StartCoroutine(CameraShake.Instance.DecreaseShake(30f, 3f));

        yield return new WaitForSeconds(2f);

        StartCoroutine(_fade.FadeToBlack(2f));
        yield return new WaitForSeconds(2f);
        Debug.Log("done");
    }
}
