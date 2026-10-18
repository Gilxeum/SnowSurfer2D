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

    public void AddScore(int score)
    {
        score += Convert.ToInt32(scoreText.text);
        scoreText.text = score.ToString("00000");
        
    }
}
