using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivePlayerMannager : MonoBehaviour
{
    public static ActivePlayerMannager Instance;

    [SerializeField] private ActivePlayer playerOne;
    [SerializeField] private ActivePlayer playerTwo;
    [SerializeField] private GameObject[] worms;

    private ActivePlayer currentPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //playerOne.AssignManager(this);
        //playerTwo.AssignManager(this);
        currentPlayer = playerOne;
    }

    private void Update()
    {
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
    
    public static ActivePlayerMannager GetInstance()
    {
        return Instance;
    }
}