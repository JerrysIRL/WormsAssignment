using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    public GameObject bullet;
    public GameObject pistol;
    public GameObject rifle;
    private bool _pistolIsActive = false;
    private bool _rifleIsActive = false;
    public int bullets = 10;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _rifleIsActive = false;
            rifle.SetActive(false);
            
            _pistolIsActive = true;
            pistol.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _pistolIsActive = false;
            pistol.SetActive(false);
            
            _rifleIsActive = true;
            rifle.SetActive(true);
        }

        if (_rifleIsActive || _pistolIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && bullets > 0)
            {
                GameObject projectile = Instantiate(bullet, gameObject.transform.position , transform.rotation);
                projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, bulletSpeed));
                bullets--;
            }
        }
        
    }

}
