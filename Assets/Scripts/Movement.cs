using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int jumpHeight = 50;
    [SerializeField] private ActivePlayerMannager manager;
    [SerializeField] private float rotationSpeed;
    public GameObject player;
    public Rigidbody rb;
    
    private float h;
    private float v;
    private bool onGround;


    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void PlayerMove()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        if (v != 0)
        {
            currentPlayer.transform.position += currentPlayer.transform.forward * (Time.deltaTime * speed * v);
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentPlayer.transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentPlayer.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }

    }

    public void PlayerJump()
        {
            if(onGround && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
                onGround = false;
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
