using UnityEngine; 
using UnityEngine.UI; 
using System.Collections; 
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour 
{
    public float playerHealth = 100; 

    public Image currentHealthbar;
    public float heal = 15;

    private int maxHitpoint = 100;
    public float damage = 10;

	private void start() 
	{ 
		UpdateHealthbar(); 
	} 
    
	private void UpdateHealthbar() 
	{
		currentHealthbar.fillAmount = playerHealth / maxHitpoint; 
	} 

	public void TakeDamage() 
	{
        print("TakeDamage");

		playerHealth -= damage;

        if (playerHealth <= 0)
        {
            playerHealth = 0; 
			Debug.Log("Dead!");
            SceneManager.LoadScene("Main Menu");
            Destroy(gameObject); 

	    } 
	
	        UpdateHealthbar(); 
	
	} 
      
	private void HealDamage() 
	{ 
		playerHealth += heal; 
		if (playerHealth > maxHitpoint) playerHealth = maxHitpoint; 
		UpdateHealthbar(); 
	} 

	public void setMaxHealth(int value){
		maxHitpoint = value;
	}

}﻿