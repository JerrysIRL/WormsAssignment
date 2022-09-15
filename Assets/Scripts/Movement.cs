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
        PlayerJump();
        PlayerMove();
    }

    private void PlayerMove()
    {
        //h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (v != 0)
        {
            transform.position += transform.forward * Time.deltaTime * speed * v;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,-rotationSpeed* Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,rotationSpeed * Time.deltaTime, 0));
        }
    }

    private void PlayerJump()
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
        if (collision.gameObject.tag == "environment")
        {
            onGround = true;
        }
    }
}
