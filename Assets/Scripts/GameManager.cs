using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 BottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject GetReady;
    public static int GameScore;
    public GameObject score;

    private void Awake()
    {
        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        gameOver = false;
        gameStarted = false;    
    }
    
    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        GameScore = score.GetComponent<Score>().GetScore();
    }
}