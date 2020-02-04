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

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }
    private void Update()
    {
        if (Time.timeScale <= 0) { return; }
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
    }
    private void LateUpdate()
    {
        if(Time.timeScale <= 0){ return;}

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
