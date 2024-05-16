using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 0;
    public int currentHealth;

    public Slider healthBar;
    
    public GameOverManager gameOverManager;
    
    

    private void Start()
    {
        //max healt will be max value of the slider component
        maxHealth = (int)healthBar.maxValue;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;

        // Ensure health doesn't go below zero
        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }

        healthBar.value = currentHealth;
        if (currentHealth == 0)
        {
            if (gameObject.transform.parent.CompareTag("Player"))
            {
                gameOverManager.LoseLevel();
            }
            
            gameObject.transform.parent.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.GetComponent<RaycastLazer>().enabled = false;
        }
        
        
    }

}
