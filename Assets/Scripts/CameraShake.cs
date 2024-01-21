using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] Transform _origin;
    [SerializeField] AnimationCurve _decreaseCurve;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine(FlatShake(0.05f, 1.5f));
        }

        if (Input.GetKeyDown("g"))
        {
            StartCoroutine(DecreaseShake(0.75f, 3f));
        }
    }

    IEnumerator FlatShake(float strength, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;
            transform.localPosition = new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = Vector3.zero;
        yield break;
    }

    IEnumerator DecreaseShake(float initialStrength, float duration)
    {
        float elapsed = 0f;
        float factor = 0f;
        while (elapsed < duration)
        {
            factor = _decreaseCurve.Evaluate(elapsed / duration);
            float x = Random.Range(-1f, 1f) * initialStrength * factor;
            float y = Random.Range(-1f, 1f) * initialStrength * factor;
            transform.localPosition = new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = Vector3.zero;
        yield break;
    }
}
