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

    [Range(2, 4)] [SerializeField]private int numTeams;

    [SerializeField] private GameObject wormsPrefab;

    private List<GameObject> worms = new List<GameObject>();

    private GameObject currentPlayer;
    private int currentWorm;
    private int lastTeam;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        SpawnTeams();
        currentPlayer = worms[currentWorm];
        GameManager.GetInstance().currentPlayerMove = currentPlayer.GetComponent<Movement>();
        GameManager.GetInstance().currentWeaponSystem = currentPlayer.GetComponent<WeaponSystem>();
    }
    
    private void SpawnTeams()
    {
        for (int i = 0; i< numTeams; i++)
        {
            Vector3 position = new Vector3(Random.Range(1, 150), 5, Random.Range(1, 150));
            GameObject worm = Instantiate(wormsPrefab, position, transform.rotation);
            worms.Add(worm);
            GameManager.GetInstance().AddTeam(worm);
        }
        currentWorm = 0;
    }


    public GameObject GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeTurn()
    {
        if (GameManager.GetInstance().TeamsAlive() <= 1)
        {
            return;
        }
        
        currentWorm++;
        if (currentWorm >= worms.Count)
        {
            currentWorm = 0;
        }
        while (worms[currentWorm].activeSelf == false)
        {
            currentWorm++;
            if (currentWorm >= worms.Count)
            {
                currentWorm = 0;
            }
        }
        
        currentPlayer = worms[currentWorm];
        
        GameManager.GetInstance().currentPlayerMove = currentPlayer.GetComponent<Movement>();
        GameManager.GetInstance().currentWeaponSystem = currentPlayer.GetComponent<WeaponSystem>();
    }
    
    public static ActivePlayerMannager GetInstance()
    {
        return Instance;
    }
}