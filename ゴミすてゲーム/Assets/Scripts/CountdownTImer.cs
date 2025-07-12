using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float startTime = 60f;
    public ThrowAwayMiniGameManager throwAwayMiniGameManager;

    private float remainingTime;
    private bool isRunning = true;

    void Start()
    {
        remainingTime = startTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (isRunning)
        {
            Debug.Log("isRunning");
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
            if (remainingTime <= 0f)
            {
                remainingTime = 0f;
                isRunning = false;
                UpdateTimerUI();
                GameOver();
                Debug.Log("GameOver");
            }
           
        }
        else
        {
            Debug.Log("isnotRunning");
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Debug.Log("Time's up!");
        throwAwayMiniGameManager.GameOver();
    }

}