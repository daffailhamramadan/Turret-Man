using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterInput : MonoBehaviour
{
    [SerializeField] private GameController gameController;


    public bool RotationRight()
    {
        if(gameController.gameState != GameController.GameState.GameOver && gameController.gameState != GameController.GameState.Start)
        {
            return Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        }

        return false;
    }

    public bool RotationLeft()
    {
        if (gameController.gameState != GameController.GameState.GameOver && gameController.gameState != GameController.GameState.Start)
        {
            return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        }

        return false;
    }

    public bool LeftMouse()
    {
        if(gameController.gameState != GameController.GameState.GameOver && gameController.gameState != GameController.GameState.Start)
        {
            return Input.GetMouseButtonDown(0);
        }

        return false;
    }

}
