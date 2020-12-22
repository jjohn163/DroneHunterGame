using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text scoreText;
    public Text ammoText;
    public Text finalScore;
    public GameObject gameOverPanel;
    public GameObject gameHUD;
    public bool gameOver = false;
    public int ammo;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ammoText.text = "Ammo: " + ammo.ToString();
    }

    public void playerScored(int pointsAwarded)
    {
        score = score + pointsAwarded;
        scoreText.text = "Score: " + score.ToString();
    }

    public void decreaseAmmo()
    {
        ammo--;

        ammoText.text = "Ammo: " + ammo.ToString();

        if (ammo <= 0)
            outofAmmo();
    }

    public void outofAmmo()
    {
        gameHUD.SetActive(false);
        finalScore.text = scoreText.text;
        gameOverPanel.SetActive(true);
        gameOver = true;
    }
}
