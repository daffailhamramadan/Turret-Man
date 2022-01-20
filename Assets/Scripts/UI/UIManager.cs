using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private TextMeshProUGUI scoreTextNumber;

    [SerializeField] private TextMeshProUGUI healthTextNumber;

    [SerializeField] private TextMeshProUGUI gameOverText;

    [SerializeField] private GameObject scoreText;

    [SerializeField] private GameObject healthText;

    [SerializeField] private TextMeshProUGUI startText;

    [SerializeField] private TextMeshProUGUI clickAnywhereText;

    [SerializeField] private TextMeshProUGUI restartText;

    [SerializeField] private TextMeshProUGUI highScoreTextNumber;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject startPanel;

    [SerializeField] private GameObject highScoreText;


    private void Start()
    {
        gameOverPanel.SetActive(false);

        scoreText.SetActive(false);

        healthText.SetActive(false);

        highScoreText.SetActive(true);
    }

    private void Update()
    {
        scoreTextNumber.text  = gameController.currentScore.ToString();

        healthTextNumber.text = gameController.currentHealth.ToString();

        highScoreTextNumber.text = "HighScore: " + gameController.HighScore.ToString();
    }


    private void OnEnable()
    {
        GameController.GameOver += GameOverUI;
        GameController.StartGame += GameStartUI;

    }

    private void OnDisable()
    {
        GameController.GameOver -= GameOverUI;
        GameController.StartGame -= GameStartUI;
    }

    public void GameStartUI()
    {
        startText.text = "";

        clickAnywhereText.text = "";

        startPanel.SetActive(false);

        scoreText.SetActive(true);

        healthText.SetActive(true);

        highScoreText.SetActive(false);

    }

    public void GameOverUI()
    {
        gameOverText.text = "Game Over";

        restartText.text = "Click R to Restart or Click Esc to Quit ";

        gameOverPanel.SetActive(true);

        scoreText.SetActive(false);

        healthText.SetActive(false);

        highScoreText.SetActive(true);
    }
}
