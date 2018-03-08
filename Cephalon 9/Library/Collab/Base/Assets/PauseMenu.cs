using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;

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
}
