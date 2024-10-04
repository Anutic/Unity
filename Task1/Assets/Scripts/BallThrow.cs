using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BallThrow : MonoBehaviour
{
    public Transform rockperf; 
    public Transform SpaunPoint; 
    public int maxThrows = 10;
    public float throwDelay = 2f; 

    private int remainingThrows; 
    private float lastThrowTime; 

    public Slider reloadSlider; 

    void Start()
    {
        ResetThrows(); 
        lastThrowTime = -throwDelay; 

        if (reloadSlider != null)
        {
            reloadSlider.maxValue = throwDelay; 
            reloadSlider.value = throwDelay;    
        }
    }

    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && remainingThrows > 0 && Time.time >= lastThrowTime + throwDelay)
        {
            Instantiate(rockperf, SpaunPoint.position, SpaunPoint.rotation); 
            remainingThrows--; 
            lastThrowTime = Time.time; 
        }

        if (reloadSlider != null)
        {
            float timeSinceLastThrow = Time.time - lastThrowTime;
            reloadSlider.value = Mathf.Clamp(throwDelay - timeSinceLastThrow, 0, throwDelay); 
        }
    }

    public void ResetThrows()
    {
        remainingThrows = maxThrows; 
    }

    public int GetRemainingThrows()
    {
        return remainingThrows;
    }
}
