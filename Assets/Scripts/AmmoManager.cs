using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public TMP_Text ammoText;
    public TMP_Text grenadeText;

    private void Update()
    {
        var currentPlayer = ActivePlayerMannager.GetInstance().GetCurrentPlayer().GetComponent<WeaponSystem>();
        ammoText.text = currentPlayer.bullets.ToString(); // displaying current player bullets
        grenadeText.text = currentPlayer.grenades.ToString(); // UI current player grenades
    }
}
