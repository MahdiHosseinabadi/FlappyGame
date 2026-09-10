using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public bool SFXEnabled;
    public bool musicEnabled;

    public static MainMenu instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SFXEnabled = true;
        musicEnabled = true;

        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }

        SceneManager.LoadScene(1);
    }

    public void ResetScore()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }
    }

    public void ResetHighScore()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetHighScore();
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleMusic()
    {
        musicEnabled = !musicEnabled;

        if (AudioManager.instance == null) return;

        if (musicEnabled)
        {
            AudioManager.instance.UnPauseMusic();
        }
        else
        {
            AudioManager.instance.PauseMusic();
        }
    }

    public void ToggleSFX()
    {
        SFXEnabled = !SFXEnabled;

        if (AudioManager.instance == null) return;

        if (!SFXEnabled)
        {
            AudioManager.instance.sfxSource.Stop();
        }
    }
}