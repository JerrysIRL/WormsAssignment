using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private int damage = 25;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= damage;
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }


    }
}