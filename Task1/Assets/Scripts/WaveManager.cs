using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 1;
    public int hitsRequired = 10;
    public int playerHits = 0;
    public GameObject basket; 
    private BoxMovement basketMovement;

    public BallThrow ballThrow;

    void Start()
    {
        basketMovement = basket.GetComponent<BoxMovement>();
    }

    void Update()
    {
        if (playerHits >= hitsRequired)
        {
            NextWave();
        }
    }

    public void RegisterHit()
    {
        playerHits++;
    }

    private void NextWave()
    {
        playerHits = 0;
        currentWave++;

        ballThrow.ResetThrows();

        if (currentWave == 2)
        {
            basketMovement.EnableMovement(1f);
        }
        else if (currentWave == 3)
        {
            basketMovement.SetSpeed(2f);
        }
        else
        {
            basketMovement.SetSpeed(1f + 0.5f * (currentWave - 3)); 
        }
    }
}
