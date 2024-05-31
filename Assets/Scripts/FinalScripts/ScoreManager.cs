using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int highScore;
    [SerializeField] private int totalScore;

    public UnityEvent<int> OntotalScoreChange;
    public UnityEvent<int> OnHighScoreChange;

    private void Awake()
    {
        TotalScore = 0;
        OntotalScoreChange.Invoke(totalScore);
        highScore = PlayerPrefs.GetInt("HScore");
        OnHighScoreChange.Invoke(highScore);
    }

    public int TotalScore
    {
        get
        {
            return totalScore;
        }

        set
        {
            totalScore = value;
            OntotalScoreChange.Invoke(totalScore);
        }
    }
    public int IncreaseScore()
    {
        //Debug.Log("Increasing score");
        TotalScore++;
        //Debug.Log("TotalScore is " + TotalScore);
        OntotalScoreChange.Invoke(totalScore);
       // Debug.Log("totalScore is " + totalScore);
        return TotalScore;
    }

    public int RegisterHighScore()
    {
        if(totalScore > highScore)
        {
            PlayerPrefs.SetInt("HScore", totalScore);
            highScore = totalScore;
            OnHighScoreChange.Invoke(highScore);
        }
        return highScore;
    }
}
