using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;

    private int score;
    private int hiscore;
    private int asteroidsRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave = 4;

    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text hiscoreText;

    // Use this for initialization
    void Start()
    {

        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void BeginGame()
    {

        score = 0;
        lives = 3;
        wave = 1;

        scoreText.text = "SCORE:" + score;
        hiscoreText.text = "HISCORE: " + hiscore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;

        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {

        DestroyExistingAsteroids();

        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {

            // spawn asteroid
            Instantiate(asteroid, new Vector3(Random.Range(-23.8f, 23.8f), Random.Range(-10.2f, 10.2f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }

        waveText.text = "WAVE: " + wave;
    }

    public void IncrementScore()
    {
        score++;

        scoreText.text = "SCORE:" + score;

        if (score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "HISCORE: " + hiscore;

            //save highscore
            PlayerPrefs.SetInt("hiscore", hiscore);
        }
        if (asteroidsRemaining < 1)
        {
            wave++;
            SpawnAsteroids();

        }
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        if (lives < 1)
        {
            BeginGame();
        }
    }

    public void DecrementAsteroids()
    {
        asteroidsRemaining--;
    }

    public void SplitAsteroid()
    {
        asteroidsRemaining += 2;

    }

    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Large Asteroid");

        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 = GameObject.FindGameObjectsWithTag("Small Asteroid");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }

}