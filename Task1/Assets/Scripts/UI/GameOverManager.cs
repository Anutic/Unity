using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameOverManager : MonoBehaviour
{
    public BallThrow ballThrow; 
    public GameObject gameOverPanel;
    public TMP_Text gameOverText; 
    public TMP_Text scoreText; 

    private Counter counter; 

    void Start()
    {
        counter = FindObjectOfType<Counter>();

        if (counter == null)
        {
            Debug.LogError("Counter script not found!");
        }

        gameOverPanel.SetActive(false); 
    }

    void Update()
    {
        if (ballThrow.GetRemainingThrows() <= 0)
        {
            GameOver(); 
        }

        if (gameOverPanel.activeSelf) 
        {
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                RestartGame(); 
            }
            else if (Input.GetKeyDown(KeyCode.E)) 
            {
                ExitGame(); 
            }
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true); 
        gameOverText.text = "Game Over!";
        scoreText.text = "Your Score: " + counter.GetScore().ToString(); 

        Time.timeScale = 0f; 
    }

    void RestartGame()
    {
        Time.timeScale = 1f; 
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
