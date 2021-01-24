using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public static UiController instance;

    void Awake()
    {
        instance = this;
        UpdateTime(1,0);
    }

    public void UpdateUI(int scoreComingIn, int scoreReach)
    {
        scoreText.text = "Score: " + scoreComingIn + "/"+ scoreReach;
    }
    public void UpdateTime(int minutes, int seconds)
    {
        //converts the timer in a string, the D2 stands for decimal format
        timeText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }

}
