using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PickUps : MonoBehaviour
{
    private int score = 0;

    public TMP_Text scoreText;


    private void Start()
    {
        scoreText.text = "SCORE:" + Scoring.totalScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Scoring.totalScore++;
            scoreText.text = "SCORE:" + Scoring.totalScore;


            collision.gameObject.SetActive(false);

            AudioManager.instance.PlaySFX(0);
        }
    }


}
