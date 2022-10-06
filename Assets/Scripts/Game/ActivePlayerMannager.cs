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
    
    private Color[] teamColors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };
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
    }
    
    private void SpawnTeams() // Instantiates teams, as well as assigns them a teamcolor.
    {
        for (int i = 0; i< numTeams; i++)
        {
            Vector3 position = new Vector3(Random.Range(10, 170), 5, Random.Range(10, 175));
            GameObject worm = Instantiate(wormsPrefab, position, transform.rotation);
            worm.GetComponent<TeamColor>().wormText.color = teamColors[i];
            worm.GetComponent<TeamColor>().wormText.text = $"Team: {i +1 }";
            worms.Add(worm);
            GameManager.GetInstance().AddTeam(worm);
        }
        currentWorm = 0;
        currentPlayer = worms[currentWorm];
        GameManager.GetInstance().currentPlayerMove = currentPlayer.GetComponent<Movement>();
        GameManager.GetInstance().currentWeaponSystem = currentPlayer.GetComponent<WeaponSystem>();
    }


    public GameObject GetCurrentPlayer() // getter for currentPlayer
    {
        return currentPlayer;
    }

    public void ChangeTurn() // called upon turn switch, check for teams alive, but also if all worms are SetActive(Die condition).
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
        GameManager.GetInstance().currentPlayerMove = currentPlayer.GetComponent<Movement>(); // making a reference to Game Manager so the next player can move and shoot
        GameManager.GetInstance().currentWeaponSystem = currentPlayer.GetComponent<WeaponSystem>();
    }
    
    public static ActivePlayerMannager GetInstance()
    {
        return Instance;
    }
}