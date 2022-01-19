using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorCollide : MonoBehaviour
{
    private GameController gameController;

    private SpriteRenderer spriteRenderer;

    private ParticleSystem[] particleSystem = new ParticleSystem[4];

    private Color32[] color = new Color32[4];

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        particleSystem[0] = GameObject.Find("BlueParticle").GetComponent<ParticleSystem>();

        particleSystem[1] = GameObject.Find("RedParticle").GetComponent<ParticleSystem>();

        particleSystem[2] = GameObject.Find("GreenParticle").GetComponent<ParticleSystem>();

        particleSystem[3] = GameObject.Find("YellowParticle").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        color[0] = new Color32(0, 96, 255, 255);

        color[1] = new Color32(255, 0, 33, 255);

        color[2] = new Color32(0, 255, 3, 255);

        color[3] = new Color32(238, 255, 0, 255);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shooter"))
        {
            gameController.TakeDamage(0.25f);
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Bullet") && collision.gameObject.GetComponent<SpriteRenderer>().color == spriteRenderer.color)
        {
            gameController.AddScore(0.25f);
            
            for(int i = 0; i < particleSystem.Length; i++)
            {
                if (spriteRenderer.color == color[i])
                {
                    particleSystem[i].transform.position = transform.position;
                    particleSystem[i].Play();
                }
            }

            Destroy(this.gameObject);
            
        }
        else if(collision.CompareTag("Bullet") && collision.gameObject.GetComponent<SpriteRenderer>().color != spriteRenderer.color)
        {
            gameController.TakeDamage(0.25f); 
        }

        
    }
}
