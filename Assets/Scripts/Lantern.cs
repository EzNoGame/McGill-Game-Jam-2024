using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] bool _shouldFlicker;
    [Range(1, 5)]
    [SerializeField] float _flickerSpeed;
    private bool _flickering;
    [SerializeField] Light _lightSource;


    void Update()
    {
        if (!_shouldFlicker) return;

        if (!_flickering) StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        _flickering = true;
        int roll = Random.Range(1, 5);
        for (int i = 0; i < roll; i++)
        {
            _lightSource.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.25f));
            _lightSource.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.25f));
        }
        yield return new WaitForSeconds(Random.Range(2f, 7f) * (float) (1f / _flickerSpeed));
        _flickering = false;
    }
}
