using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int jumpHeight = 50;
    [SerializeField] private float rotationSpeed;
    public Rigidbody rb;


    private float _v;
    private bool _onGround;


    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PlayerMove(float vertical)
    {
        transform.position += transform.forward * (Time.deltaTime * speed * vertical);
    }

    public void RotateRight()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }

    public void RotateLeft()
    {
        transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
    }

    public void PlayerJump()
    {
        if (!_onGround) return;
        rb.AddForce(Vector3.up * jumpHeight);
        _onGround = false;
    }

    private void OnCollisionEnter(Collision collision) // check if the player is on the ground before he can jump again
    {
        if (collision.gameObject.CompareTag("environment"))
        {
            _onGround = true;
        }
    }
}