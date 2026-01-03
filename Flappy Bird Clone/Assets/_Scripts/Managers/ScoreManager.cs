using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;

    public static event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        GameEvents.OnScorePointPassed += IncreaseScore;

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
        OnScoreChanged?.Invoke(currentScore);

        Debug.Log($"[ScoreManager] Score: {currentScore}");
    }

    private void HandleStateChanged(GameState state)
    {
        if (state == GameState.MainMenu || state == GameState.WaitScreen)
        {
            ResetScore();
        }
    }

    private void ResetScore()
    {
        currentScore = 0;
        OnScoreChanged?.Invoke(currentScore);

        Debug.Log("[ScoreManager] Score reset");
    }
}