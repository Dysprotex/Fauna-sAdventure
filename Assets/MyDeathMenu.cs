using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyDeathMenu : MonoBehaviour
{
    bool gameIsPaused = false;
    bool pausingGame = true;

    public GameObject DeathMenuUI;

    void Update()
    {
        
        if (Healthbehavior.healthIndex == 0 && pausingGame == true)
        {
            if (gameIsPaused)
            {
                Restart();
                pausingGame = false;
            }
            else
            {
                Pause();
                pausingGame = false;
            }
        }

    }

    public void Restart()
    {
        DeathMenuUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Pause()
    {
        DeathMenuUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
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
