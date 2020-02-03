using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(GameIsPaused == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(GameIsPaused == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        GameIsPaused = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
