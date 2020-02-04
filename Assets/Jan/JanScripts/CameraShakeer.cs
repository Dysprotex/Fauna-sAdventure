using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeer : MonoBehaviour
{
    Transform target;
    Vector3 initalPos;

    public float intensity = 10f;
    float shakeDuration;
    bool isShaking;

    void Start()
    {
        target = GetComponent<Transform>();
        initalPos = target.localPosition;
    }

    public void Shake(float duration)
    {
        if(duration > 0)
        {
            shakeDuration += duration;
        }
    }

    void Update()
    {
        if(shakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }
    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + shakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1f, 1f) * intensity, Random.Range(-1f, 1f) * intensity, initalPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }
        shakeDuration = 0;
        target.localPosition = initalPos;
        isShaking = false;
    }
}
