using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private ActivePlayer currentPlayer;
    private int currentScene;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            currentPlayer = ActivePlayerMannager.GetInstance().GetCurrentPlayer();
            currentPlayer.gameObject.GetComponent<Movement>().PlayerMove();
            currentPlayer.gameObject.GetComponent<Movement>().PlayerJump();
            currentPlayer.gameObject.GetComponent<WeaponSystem>().Shooting();
        }
    }
    
    public static GameManager GetInstance()
    {
        return instance;
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
    
    


    /* Win/lose condition
     * Scene management
     * Singleton
     * 
     *
     *
     * 
     */
}
