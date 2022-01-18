using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorCollide : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color32 color;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shooter"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Bullet") && collision.gameObject.GetComponent<SpriteRenderer>().color == spriteRenderer.color)
        {
            Destroy(this.gameObject);
        }

        
    }
}
