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

    [SerializeField] private TextMeshProUGUI startText;

    [SerializeField] private TextMeshProUGUI clickAnywhereText;

    [SerializeField] private TextMeshProUGUI restartText;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject startPanel;


    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        scoreTextNumber.text  = gameController.currentScore.ToString();

        healthTextNumber.text = gameController.currentHealth.ToString();
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

    }

    public void GameOverUI()
    {
        gameOverText.text = "Game Over";

        restartText.text = "Click R to Restart or Click Esc to Quit ";

        gameOverPanel.SetActive(true);
    }
}
