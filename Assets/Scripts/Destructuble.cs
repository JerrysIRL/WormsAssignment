using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Destructuble : MonoBehaviour
{
    private int health = 100;
    private int currentHealth;
    private int currentScene;
    public HealthBar healthBar;
    public GameObject gameOverImage;

    private void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void DoDamage(int hitPoints)
    {
        currentHealth -= hitPoints;
        healthBar.SetHealth(currentHealth);
    }
    
    public void Die()
    {
        gameObject.SetActive(false);
    }
    
    public void GameOver()
    {
        gameOverImage.SetActive(true);
        //Invoke("NextScene", delayTime);
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(currentScene + 1);
    }
    void NextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}