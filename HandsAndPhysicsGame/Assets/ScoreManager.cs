using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private int score = 0;
    private float timeRemaining = 60f;
    private bool isGameActive = false;
    private float gameDeadTime = 4f;
    private bool isDead = false;


    private void Start()
    {
        UpdateScoreText();
        UpdateTimerText();
    }

    private void Update()
    {
        if (isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            } else
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        if (!isDead)
        {
            score = 0;
            timeRemaining = 60f;
            isGameActive = true;
            UpdateScoreText();
            UpdateTimerText();
        }
    }

    private void EndGame()
    {
        isGameActive = false;
        timerText.text = "Time's up!";
        StartCoroutine(WaitForDeadTime());
    }

    internal void AddScore(int points)
    {
        if (isGameActive)
        {
            score += points;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateTimerText()
    { 
        if (isGameActive)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
        } else
        {
            timerText.text = "Pull lever to start a new game";
        }
    }

    IEnumerator WaitForDeadTime()
    {
        isDead = true;
        yield return new WaitForSeconds(gameDeadTime);
        isDead = false;
        UpdateTimerText();
    }
}