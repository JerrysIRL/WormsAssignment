using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(currentScene + 1 );
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
