using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int jumpHeight = 50;
    public GameObject player;
    public Rigidbody rb;
    [SerializeField] private float rotationSpeed;
    private float h;
    private float v;
    private bool onGround;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    public void PlayerMove()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        if (v != 0)
        {
            transform.position += transform.forward * (Time.deltaTime * speed * v);
        }
        if (h != 0)
        {
            transform.Rotate(new Vector3(0,h * rotationSpeed* Time.deltaTime, 0));
        }
        /*if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,rotationSpeed * Time.deltaTime, 0));
        }*/
    }

    public void PlayerJump()
    {
        if(onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
                onGround = false;
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("environment"))
        {
            onGround = true;
        }
    }
}
