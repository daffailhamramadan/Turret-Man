using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentScore;

    public float currentHealth;

    private int maxHealth = 3;

    private void Start()
    {
        currentScore = 0;

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
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
}
