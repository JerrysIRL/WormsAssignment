using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class ActivePlayerMannager : MonoBehaviour
{
    public static ActivePlayerMannager Instance;

    //[Range(2, 4)] [SerializeField]private int numTeams;
    [SerializeField] private GameObject wormsPrefab;
    
    private Color[] _teamColors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };
    private List<GameObject> _worms = new List<GameObject>();
    private GameObject _currentPlayer;
    private SettingManager _settingManager;
    
    private float _numOfTeams;
    private int _currentWorm;
    private int _lastTeam;

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
        
        SettingManager settingManager = FindObjectOfType<SettingManager>(); // Making sure that settings manage exists in a scene.
        if (settingManager == null)
        {
            settingManager = new GameObject("Setting Manager").AddComponent<SettingManager>();
        }
        _numOfTeams = settingManager.GetNumberOfTeams();
    }
        
    private void Start()
    {
        SpawnTeams();
    }
    
    private void SpawnTeams() // Instantiates teams, as well as assigns them a teamcolor.
    {
        for (int i = 0; i< _numOfTeams; i++)
        {
            Vector3 position = new Vector3(Random.Range(10, 170), 5, Random.Range(10, 175));
            GameObject worm = Instantiate(wormsPrefab, position, transform.rotation);
            worm.GetComponent<TeamColor>().wormText.color = _teamColors[i];
            worm.GetComponent<TeamColor>().wormText.text = $"Team: {i +1 }";
            _worms.Add(worm);
            GameManager.GetInstance().AddTeam(worm);
        }
        _currentWorm = 0;
        _currentPlayer = _worms[_currentWorm];
        GameManager.GetInstance().movement = _currentPlayer.GetComponent<Movement>();
        GameManager.GetInstance().weaponSystem = _currentPlayer.GetComponent<WeaponSystem>();
    }


    public GameObject GetCurrentPlayer() // getter for currentPlayer
    {
        return _currentPlayer;
    }

    public void ChangeTurn() // called upon turn switch, check for teams alive, but also if all worms are SetActive(Die condition).
    {
        if (GameManager.GetInstance().TeamsAlive() <= 1)
        {
            return;
        }

        _currentWorm++;
        
        if (_currentWorm >= _worms.Count)
        {
            _currentWorm = 0;
        }
       
        while (_worms[_currentWorm].activeSelf == false)
        {
            _currentWorm++;
            if (_currentWorm >= _worms.Count)
            {
                _currentWorm = 0;
            }
        }
        _currentPlayer = _worms[_currentWorm];
        GameManager.GetInstance().movement = _currentPlayer.GetComponent<Movement>(); // making a reference to Game Manager so the next player can move and shoot
        GameManager.GetInstance().weaponSystem = _currentPlayer.GetComponent<WeaponSystem>();
    }
    
    public static ActivePlayerMannager GetInstance()
    { 
        return Instance;
    }
}