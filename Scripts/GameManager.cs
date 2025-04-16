using UnityEngine;
using TMPro; // TMP'yi kullanabilmek için bu satýr þart

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TMP_Text scoreText; // <--- BURAYI GÜNCELLEDÝK

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
