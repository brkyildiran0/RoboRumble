using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 12;
    public int currentHealth;

    public Slider healthBar;

    private void Start()
    {
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
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        
        
    }

}
