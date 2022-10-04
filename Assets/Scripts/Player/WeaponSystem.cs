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
    private bool grenadeIsActive;
    private bool IsAvailable = true;

    public int bullets = 10;
    public int grenades = 3;

    public void ThrowGrenade()
    {
        if (grenadeIsActive)
        {
            if (grenades > 0 && IsAvailable == true)
            {
                GameObject frag = Instantiate(grenadePrefab, weaponHolder.transform.position, weaponHolder.transform.rotation);
                frag.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, throwY, throwZ));
                grenades--;
                StartCoroutine(GrenadeThrowDelay());
            }
        }
    }

    public void ShootPistol()
    {
        if (_pistolIsActive && bullets > 0)
        {
            GameObject projectile = Instantiate(bullet, weaponHolder.transform.position, weaponHolder.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, bulletSpeed));
            bullets--;
        }
    }

    public void DrawGrenade()
    {
        _pistolIsActive = false;
        pistol.SetActive(false);
        
        grenadeIsActive = true;
        grenade.SetActive(true);
    }

    public void DrawPistol()
    {
        grenadeIsActive = false;
        grenade.SetActive(false);

        _pistolIsActive = true;
        pistol.SetActive(true);
    }


    IEnumerator GrenadeThrowDelay()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(1f);
        IsAvailable = true;
    }
    
}   
