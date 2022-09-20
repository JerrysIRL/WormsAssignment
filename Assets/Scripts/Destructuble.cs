using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructuble : MonoBehaviour
{
    public int health = 100;
    
    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DoDamage(int hitPoints)
    {
        health -= hitPoints;
    }
}