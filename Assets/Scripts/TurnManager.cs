using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    public float timeRemaining = 10;
    public List<GameObject> wormList = new();

    
    private void Update()
    {
        wormList[0].GetComponent<Movement>().PlayerMove();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        else if (timeRemaining <= 0)
        {
            wormList[1].GetComponent<Movement>().PlayerMove(); 
        }
    }

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

    public static TurnManager GetInstance()
    {
        return instance;
    }
    
}
