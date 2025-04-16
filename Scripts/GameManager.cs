using UnityEngine;
using TMPro; // TMP'yi kullanabilmek i�in bu sat�r �art

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TMP_Text scoreText; // <--- BURAYI G�NCELLED�K

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Skor: " + score.ToString();
    }
}
