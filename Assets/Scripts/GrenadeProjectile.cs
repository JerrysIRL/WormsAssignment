using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    private bool collided = false;


    private void OnCollisionEnter(Collision collision)
    {
        CheckForPlayers();
    }


    void CheckForPlayers()
    {
        if (collided == false)
        {
            collided = true;
            Collider[] colliders = Physics.OverlapSphere(transform.position, 8f);
            foreach (Collider c in colliders)
            {
                Destructuble worm = c.GetComponent<Destructuble>();
                if (c.gameObject.CompareTag("Enemy"))
                {
                    worm.DoDamage(50);
                }
            }
            Destroy(gameObject);
        }
    }
    
}
