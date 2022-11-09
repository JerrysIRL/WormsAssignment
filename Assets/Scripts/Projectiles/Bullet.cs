using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _bulletDamage = 7;


    private void OnCollisionEnter(Collision collision) // checks for collision with the worm
    {
       if (collision.gameObject.CompareTag("Enemy"))
       {
           Destructuble destructuble = collision.gameObject.GetComponent<Destructuble>();
           destructuble.DoDamage(_bulletDamage);
           Destroy(gameObject);
       } 
    }
}
