using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private int bulletDamage = 25;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destructuble destructuble= collision.gameObject.GetComponent<Destructuble>();
            destructuble.DoDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
    
}
