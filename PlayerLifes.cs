using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifes : MonoBehaviour
{
    public float Lifes;
    

    public float CurrentLifes;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLifes = Lifes;
    }

    public void LoseLife()
    {
        CurrentLifes -= 1;
        if (CurrentLifes == 0f)
        {
            SceneManager.LoadScene("GameOver");
            
            
        }
    }
}
