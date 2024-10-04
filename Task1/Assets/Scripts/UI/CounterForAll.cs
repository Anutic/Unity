using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CounterForAll : MonoBehaviour
{
    public BallThrow ballThrow;
    public TMP_Text throwsText; 

    void Update()
    {
        throwsText.text = "Throws Left: " + ballThrow.GetRemainingThrows().ToString();
    }
}
