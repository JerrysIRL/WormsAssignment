using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletDamage = 10;


    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
       {
           Destructuble destructuble = collision.gameObject.GetComponent<Destructuble>();
           destructuble.DoDamage(bulletDamage);
           Destroy(gameObject);
       } 
    }
}
