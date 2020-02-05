using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotatiion : MonoBehaviour
{

    public float mouseSpeed = 10;
    public float rotationSpeedY = 2;

    private void OnEnable()
    {
        MyPauseMenu.OnPauseGame += MyPauseMenu_OnPauseGame;
    }

    private void OnDisable()
    {
        MyPauseMenu.OnPauseGame -= MyPauseMenu_OnPauseGame;
    }

    void Update()
    {
        rotationSpeedY += mouseSpeed * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, rotationSpeedY, 0);
       
    }

    private void MyPauseMenu_OnPauseGame(bool paused)
    {
        if(paused == true)
        {
            mouseSpeed = 0;
        }
        else
        {
            mouseSpeed = 2;
        }
    }
}
