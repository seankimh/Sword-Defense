using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        // Load High Score from PlayerPrefs, default to 0 if none exists
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Ensure Score starts at 0 every time
        score = 0;

        UpdateUI();
    }

    public void IncreaseScore()
    {
        score++; // Increase score
        UpdateUI(); // Update the score UI
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");

        // Update High Score if necessary
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save new high score
            PlayerPrefs.Save();
        }

        // Reset Score **BEFORE** reloading the scene
        score = 0;
        UpdateUI(); // Immediately update UI to show score = 0

        // Restart Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }

    // TEMPORARY: Use this function ONCE to reset high score
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
        Debug.Log("High Score Reset to 0!");

        highScore = 0; // Ensure UI updates immediately
        UpdateUI();
    }
}
