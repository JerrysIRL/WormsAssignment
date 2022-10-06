using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) // give player bullet and grenades when going threw a pickup
    {
        if (other.gameObject.CompareTag("bulletPickup"))
        {
            GetComponent<WeaponSystem>().bullets += 10;
            GetComponent<WeaponSystem>().grenades += 3;
            Destroy(other.gameObject);
        }

        
    }
}
