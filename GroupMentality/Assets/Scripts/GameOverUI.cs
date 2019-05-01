using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text text;

    void Start()
    {
        int score = ScoreManager.instance.GetScore();

        text.text = "Score: " + score.ToString();
        
        ScoreManager.instance.ResetScore();
    }
}
