using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ScoreManger scoreManger;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartingPoint;

    private Vector3 groundGenerationStartPoint;

    public GroundGenerator groundGenerator;

    public GameObject largeGround;
    public GameObject mediumGround;

    public GameObject gameOverScreen;
    void Start()
    {
        playerStartingPoint = player.transform.position;
        groundGenerationStartPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);
    }

     public void GameOver()
    {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManger.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Reset()
    {
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>(); 
        for(int i = 0; i < destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);
        }
        largeGround.SetActive(true);
        mediumGround.SetActive(true);
        player.transform.position = playerStartingPoint;
        groundGenerator.transform.position = groundGenerationStartPoint;
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        backgroundSound.Play();
        scoreManger.score = 0;
        scoreManger.isScoreIncreasing = true;
    }
}
