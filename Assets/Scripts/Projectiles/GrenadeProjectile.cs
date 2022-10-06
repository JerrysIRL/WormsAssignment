
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    private bool collided = false;
    private int grenadeDamage = 30;


    private void OnCollisionEnter(Collision collision)
    {
        CheckForPlayers();
    }


    private void CheckForPlayers() // function creates a sphere which checks if player was withing a blast radius, if yes DealDamage
    {
        if (collided == false)
        {
            collided = true;
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
            foreach (Collider c in colliders)
            {
                Destructuble worm = c.GetComponent<Destructuble>();
                if (c.gameObject.CompareTag("Enemy"))
                {
                    worm.DoDamage(grenadeDamage);
                }
            }
            Destroy(gameObject);
        }
    }
    
}
