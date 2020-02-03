using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotatiion : MonoBehaviour
{

    public float mouseSpeed = 10;
    public float rotationSpeedY = 2;

    void Update()
    {
        rotationSpeedY += mouseSpeed * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, rotationSpeedY, 0);
    }
}
