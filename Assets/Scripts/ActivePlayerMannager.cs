using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivePlayerMannager : MonoBehaviour
{
    [SerializeField] private ActivePlayer playerOne;
    [SerializeField] private ActivePlayer playerTwo;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private ActivePlayer currentPlayer;
    
    private Movement movementTwo;
    private Movement movement;
    private WeaponSystem weapon;
    private WeaponSystem weaponTwo;

    private void Awake()
    {
        
        movement = player1.GetComponent<Movement>();
        weapon = player1.GetComponent<WeaponSystem>();
        movementTwo = player2.GetComponent<Movement>();
        weaponTwo = player2.GetComponent<WeaponSystem>();
    }

    private void Start()
    {
        playerOne.AssignManager(this);
        playerTwo.AssignManager(this);
        currentPlayer = playerOne;
    }

    private void Update()
    {
        if (playerOne == currentPlayer)
        {
            movement.PlayerMove();
            movement.PlayerJump();
            weapon.ShootingWeapons();

        }
        else if (playerTwo == currentPlayer)
        {
            movementTwo.PlayerMove();
            movementTwo.PlayerJump();
            weaponTwo.ShootingWeapons();
        }
       
        ChangeTurn();
    }

    public ActivePlayer GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeTurn()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (playerOne == currentPlayer)
            {
                currentPlayer = playerTwo;
            }
                        
            else if (playerTwo == currentPlayer)
            {
                currentPlayer = playerOne;
            }
        }
        
    }
}
