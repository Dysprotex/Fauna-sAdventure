using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 5f;
    private const float Y_ANGLE_MAX = 80f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    float distance = 20f;
    float currentX;
    float currentY;
    float sensivityX;
    float sensivityY;

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
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
