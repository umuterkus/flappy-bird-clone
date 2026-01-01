using UnityEngine;
using TMPro; // TextMeshPro kütüphanesi

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Inspector'dan ata
    [SerializeField] private TextMeshProUGUI gameOverScoreText; // Oyun sonu ekranýndaki skor (Opsiyonel)

    private void OnEnable()
    {
        // ScoreManager'ýn kendi eventini dinliyoruz
        ScoreManager.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        // Oyun içi skoru güncelle
        if (scoreText != null)
        {
            scoreText.text = newScore.ToString();
        }

        // Eðer oyun sonu paneli için de bir text atadýysan onu da güncelle
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + newScore.ToString();
        }
    }
}
