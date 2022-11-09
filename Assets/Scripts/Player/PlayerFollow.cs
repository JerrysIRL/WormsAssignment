using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [Range(0.01f, 1.0f)]public float smoothFactor = 0.5f;
    public Transform cameraOffset;
    public bool rotateAroundPlayer = true;
    public float rotationsSpeed = 5;
    
    private GameObject _currentPlayer;
    private Vector3 _cameraOffset;
    
    private void Start()
    {
        _cameraOffset = transform.position - cameraOffset.transform.position; // Declaring a value for cameraOffset
    }

    private void Update()
    {
        _currentPlayer = ActivePlayerMannager.GetInstance().GetCurrentPlayer();
        FollowPlayer(_currentPlayer);
    }

    private void FollowPlayer(GameObject currentPlayer) // Function which follows the player aswell as created a Camera orbit which is controlle by mouse
    {
       
        Vector3 newPos = currentPlayer.transform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor); // look at player

        if (rotateAroundPlayer) // mouse orbit
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationsSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        if (rotateAroundPlayer)
        {
            transform.LookAt(currentPlayer.transform);
        }
    
    }
    
}
