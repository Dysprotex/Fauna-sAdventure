using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    Vector3 initalPos;
    Vector3 originalPos;

    private const float Y_ANGLE_MIN = 5f;
    private const float Y_ANGLE_MAX = 80f;

    private const float DISTANCE_MIN = 10f;
    private const float DISTANCE_MAX = 50f;


    float distance = 20f;
    float currentX;
    float currentY;
    float sensivityX;
    float sensivityY;

    public float intensity = 10f;
    float shakeDuration;
    bool isShaking;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
        initalPos = camTransform.localPosition;
    }

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        distance = Mathf.Clamp(distance, DISTANCE_MIN, DISTANCE_MAX);

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            distance += 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            distance -= 1;
        }

        if (shakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

    public void Shake(float duration)
    {
        if (duration > 0)
        {
            shakeDuration += duration;
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + shakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1f, 1f) * intensity, Random.Range(-1f, 1f) * intensity, initalPos.z);
            camTransform.localPosition = randomPoint;
            yield return null;
        }
        shakeDuration = 0;
        camTransform.localPosition = initalPos;
        isShaking = false;
    }
}
