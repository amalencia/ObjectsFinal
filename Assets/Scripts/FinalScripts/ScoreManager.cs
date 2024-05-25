using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int highScore;
    [SerializeField] private int totalScore;

    public static ScoreManager singleton;

    private void Awake()
    {
        singleton = this;
        highScore = PlayerPrefs.GetInt("HScore");
    }
    public void IncreaseScore()
    {
        totalScore++;
    }

    public void RegisterHighScore()
    {
        if(totalScore > highScore)
        {
            PlayerPrefs.SetInt("HScore", totalScore);
            highScore = totalScore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
