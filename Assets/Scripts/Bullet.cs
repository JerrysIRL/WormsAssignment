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
