using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counterText; 
    private int count = 0;
    public WaveManager waveManager;

    private void Start()
    {
        count = 0;
        UpdateCounterText(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        count += 1;
        UpdateCounterText(); 
        waveManager.RegisterHit();
    }

    private void UpdateCounterText()
    {
        counterText.text = "Count: " + count; 
    }

    public int GetScore()
    {
        return count; 
    }

}
