using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static int score;
    public static int scoreToReach;
    public static int highestScore;
    
    /// <summary>
    /// This function holds the score in a variable
    /// </summary>
    /// <param name="amount"></param>
    public static void AddScore(int amount)
    {
        score += amount;
        UiController.instance.UpdateUI(score,scoreToReach);

    }

    /// <summary>
    /// This function returns the amount of score.
    /// </summary>
    /// <returns>int</returns>
    public static int ReadScore()
    {
        
        return score;
    }
    /// <summary>
    /// Reset the score when hit the retry button, called in TimeController.
    /// </summary>
    public static void ResetScore()
    {
        score = 0;
    }
 
}
