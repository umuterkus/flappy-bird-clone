using System;
using UnityEngine;
using UnityEngine.InputSystem;

public static partial class GameEvents
{
   
    public static event Action OnScorePointPassed;
    public static event Action OnResetActivated;
    public static void RaiseScorePointPassed()
    {
        OnScorePointPassed?.Invoke();
    }
    public static void RaiseResetActivated() 
    { 
        OnResetActivated?.Invoke();
    }

    
}

public class ScoreManager : MonoBehaviour
{
    

    private int currentScore = 0;

    public static event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        // += means "add this method to the event's invocation list"
        GameEvents.OnScorePointPassed += IncreaseScore;
        GameEvents.OnResetActivated += ResetScore;

        Debug.Log("[ScoreManager] Subscribed to score events");
    }

    private void OnDisable()
    {
        GameEvents.OnScorePointPassed -= IncreaseScore;
        GameEvents.OnResetActivated -= ResetScore;

        Debug.Log("[ScoreManager] Unsubscribed from score events");
    }

    private void IncreaseScore()
    {
        currentScore++;

        OnScoreChanged?.Invoke(currentScore);

        Debug.Log($"[ScoreManager] Score increased to: {currentScore}");
    }

    // Public method for game over/restart scenarios
    private void ResetScore()
    {
        currentScore = 0;
        OnScoreChanged?.Invoke(currentScore);

        Debug.Log("[ScoreManager] Score reset");
    }

}
