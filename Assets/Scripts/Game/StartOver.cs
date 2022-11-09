using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
    private int _mainMenuScene = 0;
    

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(_mainMenuScene);
        }
            
    }
}
