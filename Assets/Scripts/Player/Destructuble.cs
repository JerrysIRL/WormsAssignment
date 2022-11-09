using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Destructuble : MonoBehaviour
{
    public HealthBar healthBar;
    public int currentHealth;
    
    private int _health = 100;
    private int _currentScene; 
    
    private void Start()
    { 
        currentHealth = _health;
        healthBar.SetMaxHealth(_health); // reference to UI
    }

    public void DoDamage(int hitPoints) // function which is responsible for players taking damage.
    {
        currentHealth -= hitPoints;
        if (currentHealth <= 0)
        {
            Die();
        }
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        GameManager.GetInstance().SomeoneDied(gameObject);
    }
}