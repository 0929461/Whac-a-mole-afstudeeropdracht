using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //variable can be called from other scripts.
    public static GameOverScript Instance;
    public Text scoreText;
    public Text levelText;
    public Text highestScoreText;
    void Start()
    {
        ScoreController.highestScore = PlayerPrefs.GetInt("highscore", ScoreController.highestScore);
        scoreText.text = "Score: " + ScoreHolder.score;
        levelText.text = "Level: " + ScoreHolder.level;
        highestScoreText.text = "HighestScore: " + ScoreController.highestScore;
        


    }
    void Update()
    {
        if (ScoreController.score > ScoreController.highestScore)
        {
            ScoreController.highestScore = ScoreController.score;
            highestScoreText.text = "HighestScore: " + ScoreController.highestScore;

        }
    }

    /// <summary>
    /// restart the game by picking up the buildnr.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

}
