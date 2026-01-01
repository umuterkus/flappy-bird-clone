using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    

    private int currentScore = 0;

    public static event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        
       GameEvents.OnScorePointPassed += IncreaseScore;
       

        Debug.Log("[ScoreManager] Subscribed to score events");
    }

    private void OnDisable()
    {
        GameEvents.OnScorePointPassed -= IncreaseScore;
        

        Debug.Log("[ScoreManager] Unsubscribed from score events");
    }

    private void IncreaseScore()
    {
        currentScore++;

        OnScoreChanged?.Invoke(currentScore);

        Debug.Log($"[ScoreManager] Score increased to: {currentScore}");
    }

    

    
    private void ResetScore()
    {
        currentScore = 0;
        OnScoreChanged?.Invoke(currentScore);

        Debug.Log("[ScoreManager] Score reset");
    }

}
