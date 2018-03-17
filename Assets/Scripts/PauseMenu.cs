using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject buttonsMenu;
    public GameObject settingsMenu;
	public GameObject upgradeMenu;

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

	public void Upgrade()
	{
		buttonsMenu.SetActive(false);
		upgradeMenu.SetActive(true);
		settingsMenu.SetActive(false);
	}

    public void Options()
    {
        buttonsMenu.SetActive(false);
		upgradeMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

	public void Back()
	{
		buttonsMenu.SetActive(true);
		upgradeMenu.SetActive(false);
		settingsMenu.SetActive(false);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
		
	public void disable(Button button){
		button.interactable = false;
	}

	public void setElectric(float d){
		ElectroBullet.setDamage(d);
	}

	public void setWater(float d){
		WaterBullet.setDamage(d);
	}
		
	public void setFire(float d){
		FireBullet.setDamage (d);
	}

	public void setBlast(float d){
		Grenade.damageMultiplier = d;
	}
}
