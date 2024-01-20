using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float shift;

    public void go()
    {
        StartCoroutine(moveElevatorDown(2f));
    }

    public IEnumerator moveElevatorDown(float duration)
    {
        Vector3 origin = transform.position;
        Vector3 target = new Vector3(origin.x, origin.y - shift, origin.z);
        float elapsed = 0f;
        float factor = 0f;
        while (elapsed < duration)
        {
            factor = (float) (elapsed / duration);
            transform.position = Vector3.Lerp(origin, target, factor);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }

 
        

}

