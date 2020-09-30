using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score;

    public Text ScoreVisual;
    public float ScoreSpeed;

    private float scoreAsInt;

    void Update()
    {
        score += ScoreSpeed * Time.deltaTime;
        scoreAsInt = Mathf.Round(score);
        
        ScoreVisual.text = scoreAsInt.ToString();
    }

    public void clearScore()
    {
        score = 0;
    }
}
