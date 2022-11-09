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
    public static GameManager Instance;

    
    private List<GameObject> _worms = new List<GameObject>();
    private bool _gameOn = false;
    private int _currentScene;
    private float _vertical;
    public Timer timer;
    public PrefabSpawner prefabSpawner;
    public Movement movement;
    public WeaponSystem weaponSystem;
    

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
        
    }
    private void Start()
    {
        prefabSpawner = FindObjectOfType<PrefabSpawner>().GetComponent<PrefabSpawner>();
        timer = FindObjectOfType<Timer>().GetComponent<Timer>();
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        if (_currentScene == 1)
        {
            _gameOn = true;
            StartCoroutine(NewRound());
            StartCoroutine(prefabSpawner.SpawnPickups());
        }
    }

    
    
    private void Update() // I know for a fact that the Update method is supposed to be clean and short,but  i did not have time to make an Input manager.
    {
        _vertical = Input.GetAxisRaw("Vertical");
        
         if (Input.anyKey && _gameOn == true)
         {
             if (_vertical != 0)
             {
                 movement.PlayerMove(_vertical);
             }

             if (Input.GetKey(KeyCode.D))
             {
                 movement.RotateRight();
             }
             if (Input.GetKey(KeyCode.A))
             {
                 movement.RotateLeft();
             }
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 movement.PlayerJump();
             }
            
             if (Input.GetKeyDown(KeyCode.Alpha1))
             {
                 weaponSystem.DrawPistol();
             }
            
             if (Input.GetKeyDown(KeyCode.Alpha2))
             {
                 weaponSystem.DrawGrenade();
             }
            
             if (Input.GetKeyDown(KeyCode.Mouse0))
             {
                 weaponSystem.ShootPistol();
             }
            
             if (Input.GetKeyDown(KeyCode.Mouse1))
             {
                 weaponSystem.ThrowGrenade();
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
        _gameOn = false;
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
         _gameOn = false;
         yield return new WaitForSeconds(3);
         _gameOn = true;
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
        SceneManager.LoadScene(_currentScene + 1);
    }
    public int TeamsAlive() // function check threw the worms, and returns the number of teams alive
    {
        int alive = 0;
        foreach (GameObject worm in _worms)
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
        _worms.Add(newTeam);
    }
    
    public static GameManager GetInstance()
    {
        return Instance;
    }
    
}
