using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    private static TurnManager instance;
    
    

    private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.T))
        {
            
        }
    }
    
    
    

    public static TurnManager GetInstance()
    {
        return instance;
    }
    
}
