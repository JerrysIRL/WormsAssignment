using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverImage;
    public static GameManager instance;
    
    private List<GameObject> worms = new List<GameObject>();
    private int currentScene;
    private float vertical;
    public Movement currentPlayerMove;
    public WeaponSystem currentWeaponSystem;

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
        if (currentScene == 1)
        {
            StartCoroutine(NewRound());
        }
    }

    
    
    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
         if (Input.anyKey)
         {
             if (vertical != 0)
             {
                 currentPlayerMove.PlayerMove(vertical);
             }

             if (Input.GetKey(KeyCode.D))
             {
                 currentPlayerMove.RotateRight();
             }
             if (Input.GetKey(KeyCode.A))
             {
                 currentPlayerMove.RotateLeft();
             }
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 currentPlayerMove.PlayerJump();
             }
            
             if (Input.GetKeyDown(KeyCode.Alpha1))
             {
                 currentWeaponSystem.DrawPistol();
             }
            
             if (Input.GetKeyDown(KeyCode.Alpha2))
             {
                 currentWeaponSystem.DrawGrenade();
             }
            
             if (Input.GetKeyDown(KeyCode.Mouse0))
             {
                 currentWeaponSystem.ShootPistol();
             }
            
             if (Input.GetKeyDown(KeyCode.Mouse1))
             {
                 currentWeaponSystem.ThrowGrenade();
             }
         }
    }
    public void SomeoneDied(GameObject deadWorm)
    {
        deadWorm.SetActive(false);
        int deadOrAlive = TeamsAlive();
        if (deadOrAlive == 1)
        {
            Debug.Log("Game Over");
            GameOver();
        }
        else
        {
            Debug.Log("number of teams alive " + deadOrAlive);
        }
    }

    
    private void GameOver()
    {
        gameOverImage.SetActive(true);
        StartCoroutine(LoadGameOverScene());
    }

    IEnumerator NewRound()
    {
        yield return new WaitForSeconds(5f);
        ActivePlayerMannager.GetInstance().ChangeTurn();
        StartCoroutine(TurnEnd());
    }

    private IEnumerator TurnEnd()
    {
        if (TeamsAlive() > 1)
        {
            StartCoroutine(NewRound());
        }
        yield return new WaitForSeconds(1f);
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(currentScene + 1);
    }
    public int TeamsAlive()
    {
        int alive = 0;
        foreach (GameObject worm in worms)
        {
            if(worm.GetComponent<Destructuble>().currentHealth > 0 )
            {
                alive += 1;
            }
        }
        return alive;
    }

    public void AddTeam(GameObject newTeam) 
    {
        worms.Add(newTeam);
    }
    
    public static GameManager GetInstance()
    {
        return instance;
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
