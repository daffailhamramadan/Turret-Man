using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterInput : MonoBehaviour
{
    public bool RotationRight()
    {
        return Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
    }

    public bool RotationLeft()
    {
        return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
    }

}
