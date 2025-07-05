using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    private int score = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI() 
    {
        scoreText.text =  score.ToString();
    }

}
