using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private AudioSource coinPickSound;
    private float coinPoints = 15f;
    private ScoreManger scoreManger;
    void Start()
    {
        coinPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoreManger = FindObjectOfType<ScoreManger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            if(coinPickSound.isPlaying )
            {
                coinPickSound.Stop();
            }
            coinPickSound.Play();
            scoreManger.score += coinPoints;
        }
    }
}
