using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameOverSound;

    [SerializeField] private AudioSource gamePlayMusic;

    private bool isPlaying;

    private bool isMusic;

    private void OnEnable()
    {
        GameController.GameOver += GameOverSound;
        GameController.StartGame += gameMusic;
    }

    private void OnDisable()
    {
        GameController.GameOver -= GameOverSound;
        GameController.StartGame -= gameMusic;
    }

    public void gameMusic()
    {
        if (!isMusic)
        {
            gamePlayMusic.Play();
            isMusic = true;
        }
    }

    public void GameOverSound()
    {
        if (!isPlaying)
        {
            gameOverSound.Play();
            isPlaying = true;
        }
        
    }
}
