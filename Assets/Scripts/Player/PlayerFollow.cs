using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform cameraOffset;
    private Vector3 _cameraOffset;
    [Range(0.01f, 1.0f)]public float smoothFactor = 0.5f;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;
    public float rotationsSpeed = 5;
    
    private void Start()
    {
        _cameraOffset = transform.position - cameraOffset.transform.position;
    }

    private void Update()
    {
        FollowPlayer(ActivePlayerMannager.GetInstance().GetCurrentPlayer());
    }

    private void FollowPlayer(GameObject currentPlayer)
    {
       
        Vector3 newPos = currentPlayer.transform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor); // look at player

        if (rotateAroundPlayer) // mouse orbit
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationsSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(currentPlayer.transform);
        }
    
    }
    
}