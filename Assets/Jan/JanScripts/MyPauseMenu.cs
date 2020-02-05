using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{
    bool gameIsPaused = false;
    public bool pausingGame;

    public GameObject PauseMenuUI;

    public delegate void PauseGame(bool paused);
    public static event PauseGame OnPauseGame;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
       
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;

        OnPauseGame?.Invoke(gameIsPaused);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;

        OnPauseGame?.Invoke(gameIsPaused);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        gameIsPaused = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
