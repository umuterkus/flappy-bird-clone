using UnityEngine;
using TMPro;
using DG.Tweening;
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private TextMeshProUGUI gameOverScoreText; 
    private void OnEnable()
    {
        
        ScoreManager.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {

        if (scoreText != null)
        {
            scoreText.text = newScore.ToString();
            scoreText.transform.DORewind(); //resets old anim
            scoreText.transform.DOPunchScale(new Vector3(0.8f, 0.8f, 0.8f), 0.4f, 10, 0.5f); 
        }

        // Eðer oyun sonu paneli için de bir text atadýysan onu da güncelle
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + newScore.ToString();
        }
    }
}
