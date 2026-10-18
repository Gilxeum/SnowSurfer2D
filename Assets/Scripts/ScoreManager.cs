using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this; // "this" = este objeto ScoreManager concreto
    }

    public void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString("00000");
    }

    public void AddScore(int score)
    {
        score += Convert.ToInt32(scoreText.text);
        scoreText.text = score.ToString("00000");
        
    }

    public void SaveScore()
    {
        int score = Convert.ToInt32(scoreText.text);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + score);
        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString("00000");
    }
}
