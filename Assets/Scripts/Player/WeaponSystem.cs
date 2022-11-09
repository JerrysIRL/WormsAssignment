using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField]private int throwY;
    [SerializeField]private int throwZ;
    [SerializeField] private GameObject weaponHolder;
   
    public GameObject bullet;
    public GameObject pistol;
    public GameObject grenade;
    public GameObject grenadePrefab;
    
    private bool _pistolIsActive;
    private bool _grenadeIsActive;
    private bool _isAvailable = true;

    public int bullets = 10;
    public int grenades = 3;

    public void ThrowGrenade() // Method for instantiating grenade from player
    {
        if (_grenadeIsActive)
        {
            if (grenades > 0 && _isAvailable)
            {
                GameObject frag = Instantiate(grenadePrefab, weaponHolder.transform.position, weaponHolder.transform.rotation);
                frag.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, throwY, throwZ));
                grenades--;
                StartCoroutine(GrenadeThrowDelay());
            }
        }
    }

    public void ShootPistol() // shooting the pistol 
    {
        if (_pistolIsActive && bullets > 0)
        {
            GameObject projectile = Instantiate(bullet, weaponHolder.transform.position, weaponHolder.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, bulletSpeed));
            bullets--;
            StartCoroutine(ShootingDelay());
        }
    }

    public void DrawGrenade() // showing a 3D model of the weapon player is using 
    {
        _pistolIsActive = false;
        pistol.SetActive(false);
        
        _grenadeIsActive = true;
        grenade.SetActive(true);
    }

    public void DrawPistol()
    {
        _grenadeIsActive = false;
        grenade.SetActive(false);

        _pistolIsActive = true;
        pistol.SetActive(true);
    }


    IEnumerator GrenadeThrowDelay() // Delays for the different guns
    {
        _isAvailable = false;
        yield return new WaitForSeconds(0.6f);
        _isAvailable = true;
    }
    IEnumerator ShootingDelay()
    {
        _isAvailable = false;
        yield return new WaitForSeconds(0.2f);
        _isAvailable = true;
    }
    
}   
