using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class WaveUI : MonoBehaviour
{
    public WaveManager waveManager;
    public TMP_Text waveText; 

    void Update()
    {
        if (waveManager == null || waveText == null)
        {
            Debug.LogError("WaveManager or TMP_Text is not assigned.");
            return;
        }

        waveText.text = "Wave: " + waveManager.currentWave.ToString();
    }
}
