using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    
    public int gameTime=60;
    int seconds, minutes;
    public static int currentLevel = 1;
    int baseScore = 100;
    int scoreToReachInTime;
    static bool hasLost;
   
    void Start()
    {
        if (hasLost)
        {
            hasLost = false;
            ScoreController.ResetScore();
            currentLevel = 1;
        }
        scoreToReachInTime = currentLevel * (baseScore*currentLevel);
        ScoreController.scoreToReach = scoreToReachInTime;
        UiController.instance.UpdateUI(0, scoreToReachInTime);
        StartCoroutine(SetGameTime());
        
    }

    /// <summary>
    /// this function handles the gametime.
    /// the gametime is also in the inspector which can be easy change
    /// </summary>
    /// <returns></returns>
    public IEnumerator SetGameTime()
    {
        while (gameTime>0)
        {
            yield return new WaitForSeconds(1);
            gameTime--;
            seconds = gameTime % 60;
            minutes = gameTime / 60 % 60;
            //updating UI
            UiController.instance.UpdateTime(minutes,seconds);
        }
        CheckForWin();
    }

    /// <summary>
    /// if the readscore function is more then the score you have to reach
    /// </summary>
    void CheckForWin()
    {
        if(ScoreController.ReadScore() >= scoreToReachInTime)
        {
            currentLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            hasLost = true;
            //read the score
            ScoreHolder.score = ScoreController.ReadScore();
            ScoreHolder.level = currentLevel;            
            SceneManager.LoadScene("GameOver");

        }
    }

}
