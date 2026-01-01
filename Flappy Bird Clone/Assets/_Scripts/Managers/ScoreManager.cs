using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;

    // UI'ýn dinleyeceði event (Skor deðiþtiðinde UI'a haber verir)
    public static event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        // Puan kazanmayý dinle
        GameEvents.OnScorePointPassed += IncreaseScore;

        // YENÝ: Oyun durumunu dinle (Resetlemek için)
        GameEvents.OnStateChanged += HandleStateChanged;

        Debug.Log("[ScoreManager] Events Subscribed");
    }

    private void OnDisable()
    {
        GameEvents.OnScorePointPassed -= IncreaseScore;
        GameEvents.OnStateChanged -= HandleStateChanged;

        Debug.Log("[ScoreManager] Events Unsubscribed");
    }

    private void IncreaseScore()
    {
        currentScore++;
        // Skoru UI'a gönder
        OnScoreChanged?.Invoke(currentScore);

        Debug.Log($"[ScoreManager] Score: {currentScore}");
    }

    // State Machine'den gelen duruma göre reset at
    private void HandleStateChanged(GameState state)
    {
        // Ana menüye dönüldüðünde veya Restart atýlýp WaitScreen'e geçildiðinde
        if (state == GameState.MainMenu || state == GameState.WaitScreen)
        {
            ResetScore();
        }
    }

    private void ResetScore()
    {
        currentScore = 0;
        // Sýfýrlanan skoru UI'a bildir ki ekranda 0 yazsýn
        OnScoreChanged?.Invoke(currentScore);

        Debug.Log("[ScoreManager] Score reset");
    }
}