using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int playeScene = 1;
    public void PlayGame()
    {
        SceneManager.LoadScene(playeScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
