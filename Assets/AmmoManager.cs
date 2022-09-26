using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public TMP_Text ammoText;
    public TMP_Text grenadeText;
    public ActivePlayerMannager manager;
    private ActivePlayer currentPlayer;
    private WeaponSystem weaponSystem;
    

    private void Update()
    {
        currentPlayer = manager.GetCurrentPlayer();
        weaponSystem = currentPlayer.GetComponent<WeaponSystem>();
        ammoText.text = weaponSystem.bullets.ToString(); // displaying current player bullets
        grenadeText.text = weaponSystem.grenades.ToString(); // UI current player grenades
    }
}
