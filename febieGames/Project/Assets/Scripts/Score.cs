using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;



    public void IncrementScore()
    {

        score++;
        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("ScoreToUpdate", PlayerPrefs.GetInt("ScoreToUpDate", 0) + 1);
    }
}
