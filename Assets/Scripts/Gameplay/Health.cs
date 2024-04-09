using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar; // Assign your health bar Slider in the inspector

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Ensure health doesn't go below zero
        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }

        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            // Add game over or death logic here
        }
    }
}
