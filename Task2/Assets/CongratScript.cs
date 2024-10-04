using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CongratScript : MonoBehaviour
{
    public TextMeshPro Text;  
    public ParticleSystem SparksParticles; 
    public ParticleSystem SparksParticles2;
    public ParticleSystem ConfettiParticles;

    private List<string> TextToDisplay;

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

   
    void Start()
    {
        TextToDisplay = new List<string>();

        TimeToNextText = 0.0f;
        CurrentText = 0;

        TextToDisplay.Add("Congratulations!");
        TextToDisplay.Add("All Errors Fixed!");
        TextToDisplay.Add("Enjoy the Celebration!");

        if (Text != null)
        {
            Text.text = TextToDisplay[0];
            Text.fontSize = 30;  
            Text.color = Color.yellow; 
        }
        else
        {
            Debug.LogError("TextMeshPro компонент не назначен в инспекторе.");
        }

        if (SparksParticles != null)
        {
            SparksParticles.Play();
        }
        else
        {
            Debug.LogError("ParticleSystem (Sparks) не назначен в инспекторе.");
        }
        if (SparksParticles2 != null)
        {
            SparksParticles2.Play();
        }
        else
        {
            Debug.LogError("ParticleSystem (Sparks) не назначен в инспекторе.");
        }

        if (ConfettiParticles != null)
        {
            ConfettiParticles.Play();
        }
        else
        {
            Debug.LogError("ParticleSystem (Confetti) не назначен в инспекторе.");
        }

       StartCoroutine(AnimateTextAppearance());
    }

    IEnumerator AnimateTextAppearance()
    {
        float duration = 0.5f;
        float elapsedTime = 0.0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Text.transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
        }
    }

    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 2.0f)  
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }

            if (Text != null)
            {
                Text.text = TextToDisplay[CurrentText];
                StartCoroutine(AnimateTextAppearance());  
            }
        }

    }
}
