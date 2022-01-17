using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotation : MonoBehaviour
{
    private ShooterInput shooterInput;

    private void Awake()
    {
        shooterInput = GetComponent<ShooterInput>();
    }

    private void Update()
    {
        if (shooterInput.RotationRight())
        {
            transform.Rotate(0f, 0f, -90f);
        }

        if (shooterInput.RotationLeft())
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
