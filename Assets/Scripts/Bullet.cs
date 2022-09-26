using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletDamage = 15;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destructuble destructuble = other.gameObject.GetComponent<Destructuble>();
            destructuble.DoDamage(bulletDamage);
            Destroy(gameObject);
        }

    }
}
