using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;
    
    private float _numOfTeams = 2;
    
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
        DontDestroyOnLoad(gameObject);
    }

    public void SetNumberOfTeams(float numTeams)
    {
        _numOfTeams = numTeams;
        Debug.Log("teams is now " + _numOfTeams);
    }

    public float GetNumberOfTeams()
    {
        return _numOfTeams;
    }
    
   
}
