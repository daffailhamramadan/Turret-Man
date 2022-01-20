using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public float currentScore;

    [HideInInspector] public float currentHealth;

    private int maxHealth = 3;

    public delegate void GameOverEvent();

    public static event GameOverEvent GameOver;

    public delegate void StartEvent();

    public static event StartEvent StartGame;

    public float HighScore;

    public enum GameState
    {
        Start,

        GamePlay,

        GameOver
    }

    public GameState gameState;

    private void Start()
    {
        gameState = GameState.Start;

        if(gameState == GameState.Start)
        {
            Time.timeScale = 0f;

            currentScore = 0;

            currentHealth = maxHealth;
        }

    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            gameState = GameState.GameOver;
        }

        if (Input.GetMouseButtonDown(0) && gameState == GameState.Start)
        {
            StartGame?.Invoke();

            gameState = GameState.GamePlay;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gameState == GameState.GamePlay)
        {
            Application.Quit();
        }

        if(gameState == GameState.GameOver)
        {
            GameOver?.Invoke();
        }

        HighScore = PlayerPrefs.GetFloat("HighScore");

    }

    public void AddScore(float score)
    {
        currentScore = currentScore + score;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
    }

    private void OnEnable()
    {
        GameOver += GameOverLogic;
        StartGame += StartGameLogic;
    }

    private void OnDisable()
    {
        GameOver -= GameOverLogic;
        StartGame -= StartGameLogic;
    }

    public void StartGameLogic()
    {
        Time.timeScale = 1f;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameOverLogic()
    {
        Time.timeScale = 0f;

        if(PlayerPrefs.GetFloat("HighScore") < currentScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }  
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
