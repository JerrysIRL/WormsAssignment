using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField]private int throwY;
    [SerializeField]private int throwZ;
    [SerializeField] private ActivePlayerMannager manager;
    [SerializeField] private GameObject weaponHolder;
    public GameObject bullet;
    public GameObject pistol;
    public GameObject grenade;
    public GameObject grenadePrefab;
    private bool _pistolIsActive = false;
    private bool grenadeIsActive = false;
    
    public int bullets = 10;
    public int grenades = 10;
    
    public void ShootingWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            grenadeIsActive = false;
            grenade.SetActive(false);

            _pistolIsActive = true;
            pistol.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _pistolIsActive = false;
            pistol.SetActive(false);

            grenadeIsActive = true;
            grenade.SetActive(true);
        }

        if (_pistolIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && bullets > 0)
            {
                GameObject projectile =
                    Instantiate(bullet, weaponHolder.transform.position, weaponHolder.transform.rotation);
                projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, bulletSpeed));
                bullets--;
            }
        }

        if (grenadeIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && grenades > 0)
            {
                GameObject frag = Instantiate(grenadePrefab, weaponHolder.transform.position,
                    weaponHolder.transform.rotation);
                frag.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, throwY, throwZ));
                grenades--;
            }
        }
    }
}   
