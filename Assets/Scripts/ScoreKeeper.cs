using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static int score, highScore;
    public Text scoreText, highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = -1;
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Highest Score: "+highScore;
        score = 0;
        scoreText.text = "Score: "+score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score = score + 1;
        scoreText.text = "Score: "+score;

        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
            highScoreText.text = "Highest Score: "+highScore;
        }
    }

    public int getScore()
    {
        return score;
    }
}
