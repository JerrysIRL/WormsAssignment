using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider teamsSlider;
    private SettingManager _settingManager;
    private int _playerScene = 1;


    private void Awake()
    {
        _settingManager = FindObjectOfType<SettingManager>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(_playerScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void Start()
    {
        teamsSlider.value = 2;
    }

    public void SliderChanged()
    {
        _settingManager.SetNumberOfTeams(teamsSlider.value);
    }
}
