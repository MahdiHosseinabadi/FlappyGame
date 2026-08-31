using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static int CurrentScore;
    public int HighScore;
    public Text TextHighScore;
    public Text TextScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentScore = 0;
        TextScore.text = CurrentScore.ToString();
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        TextHighScore.text = HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }

        TextScore.text = CurrentScore.ToString();
        TextHighScore.text = HighScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
        HighScore = 0;
        TextHighScore.text = HighScore.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
