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
    [Range(1,1)] [SerializeField]private int numWorms;
    
    [SerializeField] private GameObject wormsPrefab;

    private List<List<GameObject>> worms = new List<List<GameObject>>();

    private GameObject currentPlayer;
    public int currentTeam;
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
        currentPlayer = worms[currentTeam][currentWorm];
        GameManager.GetInstance().currentPlayerMove = currentPlayer.GetComponent<Movement>();
        GameManager.GetInstance().currentWeaponSystem = currentPlayer.GetComponent<WeaponSystem>();
        lastTeam = numTeams -1;
    }
    
    private void SpawnTeams()
    {
        for (int i = 0; i < numTeams; i++)
        {
            worms.Add(new List<GameObject>());
            GameObject team = new GameObject();
            team.name = "Team" + (i + 1);
            
            for (int I = 0; I < numWorms; I++)
            {
                Vector3 position = new Vector3(Random.Range(1, 150), 5, Random.Range(1, 150));
                GameObject worm = Instantiate(wormsPrefab, position, transform.rotation);
                worm.transform.SetParent(team.transform);
                worms[i].Insert(I,worm);
            }
            GameManager.GetInstance().AddTeam(team);
        }
        currentTeam = 0;
        currentWorm = 0;
    }

    
    public GameObject GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeTurn()
    {
        if (worms[currentTeam][currentWorm].transform.childCount > 0)
        {
            if(currentTeam <= worms[currentTeam].Count - 1)
            {
                Debug.Log("Change Team");
                currentTeam++;
                currentPlayer = worms[currentTeam][currentWorm];
            }
            else
            {
                Debug.Log("Reset Team");
                currentTeam = 0;
                currentPlayer = worms[currentTeam][currentWorm];
            }
            GameManager.GetInstance().currentPlayerMove = currentPlayer.GetComponent<Movement>();
            GameManager.GetInstance().currentWeaponSystem = currentPlayer.GetComponent<WeaponSystem>();
        }
        else if(GameManager.GetInstance().TeamsAlive() > 1)
        {
            currentTeam++;
            ChangeTurn();
        }
    }
    
    public static ActivePlayerMannager GetInstance()
    {
        return Instance;
    }
}