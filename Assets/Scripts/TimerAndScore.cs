using UnityEngine;
using TMPro;

public class TimerAndScore : MonoBehaviour
{
    [Header("Runtime UI")]
    public TextMeshProUGUI timerText; 

    [Header("Level Complete UI")]
    public TextMeshProUGUI finalTimeText;  
    public TextMeshProUGUI finalScoreText; 

    [Header("Scoring")]
    public int baseScore = 1000;
    public int penaltyPerSecond = 5;

    float elapsedTime = 0f;
    bool isRunning = true;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
        if (timerText != null) timerText.text = "00:00";
        if (finalTimeText != null) finalTimeText.text = "Time: 00:00.00";
        if (finalScoreText != null) finalScoreText.text = "Score: 000";
    }

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public int GetScore()
    {
        int score = Mathf.Max(0, baseScore - Mathf.FloorToInt(elapsedTime) * penaltyPerSecond);
        return score;
    }
    
    public void OnLevelComplete()
    {
        StopTimer();
        
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int centis = Mathf.FloorToInt((elapsedTime - Mathf.Floor(elapsedTime)) * 100f);
        string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, centis);
        
        if (finalTimeText != null) finalTimeText.text = "Time: " + formattedTime;
        if (finalScoreText != null) finalScoreText.text = "Score: " + GetScore().ToString("000");
    }
}
