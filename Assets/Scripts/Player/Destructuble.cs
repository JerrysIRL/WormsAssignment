using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Destructuble : MonoBehaviour
{
    private int health = 100;
    public int currentHealth;
    private int currentScene;
    public HealthBar healthBar;

    private void Start()
    { 
        currentHealth = health;
        healthBar.SetMaxHealth(health); // reference to UI
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