using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BillboardCounter : MonoBehaviour
{
    public Text scoreText;
    public Text deliveryText;

    public int score;
    public int deliveryRemaining;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        deliveryRemaining = 5;
        scoreText.text = "Score: " + score.ToString();
        deliveryText.text = "Deliveries Allowed: " + deliveryRemaining.ToString();
    }

    // Deliveries remaining is essenially lives, once it reaches zero, you lose
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        deliveryText.text = "Deliveries Allowed:  " + deliveryRemaining.ToString();

        if (deliveryRemaining < 1)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
