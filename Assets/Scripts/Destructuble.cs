using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructuble : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DoDamage(int hitPoints)
    {
        currentHealth -= hitPoints;
        healthBar.SetHealth(currentHealth);
    }
}