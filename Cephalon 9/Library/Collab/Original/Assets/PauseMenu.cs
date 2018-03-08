using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject buttonsMenu;
    public GameObject settingsMenu;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
	}

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        buttonsMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
