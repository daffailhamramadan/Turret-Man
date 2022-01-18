using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorCollide : MonoBehaviour
{
    private GameController gameController;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shooter"))
        {
            Destroy(this.gameObject);
            gameController.TakeDamage(0.25f);
        }

        if (collision.CompareTag("Bullet") && collision.gameObject.GetComponent<SpriteRenderer>().color == spriteRenderer.color)
        {
            Destroy(this.gameObject);
            gameController.AddScore(1.25f);
        }
        else
        {
            gameController.TakeDamage(0.25f); 
        }

        
    }
}
