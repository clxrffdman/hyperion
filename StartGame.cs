using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text ScoreVisual;

    private float scoreAsInt;

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
        
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver") 
        {
            scoreAsInt = Mathf.Round(Score.score);

            ScoreVisual.text = "Score: " + scoreAsInt.ToString();
        }
    }
}
