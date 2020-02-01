using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotatiion : MonoBehaviour
{

    float mouseSpeed = 10;
    float rotationSpeedY = 3;

    void Update()
    {
        rotationSpeedY += mouseSpeed * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, rotationSpeedY, 0);
    }
}
