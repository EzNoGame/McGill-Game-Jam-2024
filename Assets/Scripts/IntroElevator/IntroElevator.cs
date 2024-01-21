using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public enum Sequence
{
    LORE,
    CONTROLS,
    FALL
}

public class IntroElevator : MonoBehaviour
{
    [SerializeField] VideoPlayer _player;
    [SerializeField] RawImage _image;
    [SerializeField] BlackFade _fade;
    [SerializeField] Image _bigBlack;
    private Sequence _sequence;

    void Awake()
    {
        _sequence = Sequence.LORE;
    }

    void Start()
    {
        StartCoroutine(Enter());
    }

    private void Update()
    {
        if (Input.GetKeyDown("j"))
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
        _image.texture = _player.texture;
        _player.Play();
        _player.isLooping = true;

        _bigBlack.enabled = false;
        StartCoroutine(_fade.FadeFromBlack(2f));

        StartCoroutine(CameraShake.Instance.BeginBounce(10f));

        yield return null;
    }

    public IEnumerator Fall()
    {
        CameraShake.Instance.EndBounce();
        float elapsed = 0f;
        float duration = 2.5f;
        float maxSpeed = 10f;

        StartCoroutine(CameraShake.Instance.FlatShake(5f, duration + 1f));
        while (elapsed < duration)
        {
            float factor = elapsed / duration;
            _player.playbackSpeed = Mathf.Lerp(1, maxSpeed, factor);
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        _player.playbackSpeed = 0f;
        StartCoroutine(CameraShake.Instance.DecreaseShake(40f, 3f));

        yield return new WaitForSeconds(2f);

        StartCoroutine(_fade.FadeToBlack(2f));
        yield return new WaitForSeconds(2f);
        _bigBlack.enabled = true;
        SceneManager.LoadScene("MainLevel");
    }
}
