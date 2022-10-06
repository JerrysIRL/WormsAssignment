using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float secondsLeft = 7;
    private float _roundDelay = 3;
    
    private void Update()
    {
        if (secondsLeft > 0) // Round Timer
        {
            secondsLeft -= Time.deltaTime;
            timerText.color = Color.black;
            timerText.text = secondsLeft.ToString("F0");
            _roundDelay = 3;
        }

        if (secondsLeft < 0) // Delay when the players switch turns
        {
            StartCoroutine(DelayBetweenRounds());
            _roundDelay -= Time.deltaTime;
            timerText.color = Color.red;
            timerText.text = _roundDelay.ToString("F0");
            
            
        }
        
    }
    private IEnumerator DelayBetweenRounds()
    {
        yield return new WaitForSeconds(_roundDelay);
        secondsLeft = 7;
    }
}
