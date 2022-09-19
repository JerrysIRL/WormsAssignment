using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletPickup")
        {
            GetComponentInChildren<WeaponSystem>().bullets += 10;
            Destroy(other.gameObject);
        }
    }
}
