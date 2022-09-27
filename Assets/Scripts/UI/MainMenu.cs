using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Ha kvar här för event referens
    public void PlayGame()
    {
        GameManager.GetInstance().LoadScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
