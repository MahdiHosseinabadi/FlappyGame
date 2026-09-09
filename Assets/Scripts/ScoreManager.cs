using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    public static Action<int> OnScoreChanged;
    public static Action<int> OnHighScoreChanged;

    private const string HighScoreKey = "HighScore";

    public static ScoreManager instance;

    void Awake()
    {
        instance = this;

        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        CurrentScore = 0;
    }

    public void AddScore()
    {
        CurrentScore++;

        OnScoreChanged?.Invoke(CurrentScore);

        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;

            PlayerPrefs.SetInt(HighScoreKey, HighScore);
            PlayerPrefs.Save();

            OnHighScoreChanged?.Invoke(HighScore);
        }
    }

    public void ResetScore()
    {
        CurrentScore = 0;

        OnScoreChanged?.Invoke(CurrentScore);
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, HighScore);
        PlayerPrefs.Save();
    }

    public void ResetHighScore()
    {
        HighScore = 0;

        PlayerPrefs.SetInt(HighScoreKey, 0);
        PlayerPrefs.Save();

        OnHighScoreChanged?.Invoke(HighScore);
    }
}