using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused =false;
    public GameObject pauseMenuUi;
    public GameObject player;

    // Update is called once per frame
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
    }

    public void Resume()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerInteract>().enabled = true;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    void Pause()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerInteract>().enabled = false;
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting menu...");
        Application.Quit();
    }
}
