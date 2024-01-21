using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    private static CameraShake _instance;
    public static CameraShake Instance { get { return _instance; } }
    private Camera _cam;
    [SerializeField] Transform _origin;
    [SerializeField] AnimationCurve _decreaseCurve;
    [SerializeField] AnimationCurve _bounceCurve;

    private bool _isBouncing;
    private bool _isChased;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        _instance = this;
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

        if (Input.GetKeyDown("p"))
        {
            StartCoroutine(Bounce(0.2f));
        }

        if (Input.GetKeyDown("c"))
        {
            StartCoroutine(BeginChased(10f));
        }
    }

    public IEnumerator FlatShake(float strength, float duration)
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

    public IEnumerator DecreaseShake(float initialStrength, float duration)
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

    public IEnumerator BeginBounce(float strength)
    {
        _isBouncing = true;
        while (_isBouncing)
        {
            StartCoroutine(Bounce(strength));
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void EndBounce()
    {
        _isBouncing = false;
    }

    public IEnumerator Bounce(float strength)
    {
        float elapsed = 0f;
        float duration = _bounceCurve[_bounceCurve.length - 1].time;
        Debug.Log($"dur{duration}");
        float factor = 0f;
        while (elapsed < duration)
        {
            factor = _bounceCurve.Evaluate(elapsed / duration);
            Debug.Log($"fac{factor}");
            transform.localPosition = new Vector3(0f, factor * strength, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.localPosition = Vector3.zero;
        yield break;
    }

    public IEnumerator BeginChased(float strength)
    {
        _isChased = true;
        while (_isChased)
        {
            StartCoroutine(FlatShake(strength, 0.1f));
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void EndChased()
    {
        _isChased = false;
    }

}
