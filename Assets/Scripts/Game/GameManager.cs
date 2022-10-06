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
    private bool gameON = false;
    private int currentScene;
    private float vertical;
    public Timer timer;
    public PrefabSpawner prefabSpawner;
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
        prefabSpawner = FindObjectOfType<PrefabSpawner>().GetComponent<PrefabSpawner>();
        timer = FindObjectOfType<Timer>().GetComponent<Timer>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 1)
        {
            gameON = true;
            StartCoroutine(NewRound());
            StartCoroutine(prefabSpawner.SpawnPickups());
        }
    }

    
    
    private void Update() // I know for a fact that the Update method is supposed to be clean and short,but  i did not have time to make an Input manager.
    {
        vertical = Input.GetAxisRaw("Vertical");
        
         if (Input.anyKey && gameON == true)
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
    public void SomeoneDied(GameObject deadWorm) // reference for the GameManager when someone dies, check win/lose condition
    {
        deadWorm.SetActive(false);
        int deadOrAlive = TeamsAlive();
        if (deadOrAlive == 1)
        {
            GameOver();
        }
    }

    
    private void GameOver() 
     {
        gameON = false;
        gameOverImage.SetActive(true);
        StartCoroutine(LoadGameOverScene());
    }

    IEnumerator NewRound() // coroutine for starting new rounds
    {
        yield return new WaitForSeconds(7);
        StartCoroutine(PlayerSwitchDelay());

    }
     IEnumerator PlayerSwitchDelay() // delay when round ends
     {
         gameON = false;
         yield return new WaitForSeconds(3);
         gameON = true;
         ActivePlayerMannager.GetInstance().ChangeTurn();
         TurnEnd();
     }
     
    private void TurnEnd() // check for teams alive, if more than 1, start a new round
    {
        if (TeamsAlive() > 1)
        {
            StartCoroutine(NewRound());
        }
    }
    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(currentScene + 1);
    }
    public int TeamsAlive() // function check threw the worms, and returns the number of teams alive
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
    
}
