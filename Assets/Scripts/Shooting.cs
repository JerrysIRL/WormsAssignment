using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    public GameObject bullet;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject ball = Instantiate(bullet, gameObject.transform.position , transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, bulletSpeed));
        }
    }
}
