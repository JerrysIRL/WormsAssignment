using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Destructuble : MonoBehaviour
{
    public int health = 100;
    private int currentHealth;
    private int currentScene;
    //public HealthBar healthBar;

    private void Start()
    {
        currentHealth = health;
       //healthBar.SetMaxHealth(health);
    }

    public void DoDamage(int hitPoints)
    {
        currentHealth -= hitPoints;
        if (currentHealth <= 0)
        {
            Die();
        }
        //healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        GameManager.GetInstance().SomeoneDied(gameObject);
    }
}