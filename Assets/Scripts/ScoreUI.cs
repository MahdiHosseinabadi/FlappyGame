using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text TextScore;
    public Text TextHighScore;

    void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
        ScoreManager.OnHighScoreChanged += UpdateHighScore;
    }

    void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScore;
        ScoreManager.OnHighScoreChanged -= UpdateHighScore;
    }

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            UpdateScore(ScoreManager.instance.CurrentScore);
            UpdateHighScore(ScoreManager.instance.HighScore);
        }
    }

    void UpdateScore(int score)
    {
        if (TextScore != null)
            TextScore.text = "Score: " + score;
    }

    void UpdateHighScore(int highScore)
    {
        if (TextHighScore != null)
            TextHighScore.text = "HighScore: " + highScore;
    }
}