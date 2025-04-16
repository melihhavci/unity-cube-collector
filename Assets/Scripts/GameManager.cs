using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TMP_Text scoreText;

    [Header("Oyun Süresi")]
    public float gameDuration = 60f;
    private float remainingTime;
    private bool gameEnded = false;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        remainingTime = gameDuration;
        Time.timeScale = 1f;
        UpdateScoreUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                EndGame();
            }
        }
    }

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Skor: " + score.ToString();
    }

    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Oyun Bitti!\nSkor: " + score.ToString();
        }

        Debug.Log("Oyun bitti, skor: " + score);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyun kapatýldý.");
    }

}
