using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bulletPickup"))
        {
            GetComponent<WeaponSystem>().bullets += 10;
            GetComponent<WeaponSystem>().grenades += 3;
            Destroy(other.gameObject);
        }
    }
}
