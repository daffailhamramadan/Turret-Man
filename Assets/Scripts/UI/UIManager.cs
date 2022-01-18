using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private TextMeshProUGUI scoreTextNumber;

    [SerializeField] private TextMeshProUGUI healthTextNumber;

    private void Update()
    {
        scoreTextNumber.text  = gameController.currentScore.ToString();

        healthTextNumber.text = gameController.currentHealth.ToString();
    }
}
