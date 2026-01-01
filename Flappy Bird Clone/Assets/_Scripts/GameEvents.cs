using System;
using UnityEngine;

public static class GameEvents
{

    //GAME MANAGER
    public static event Action<GameState> OnStateChanged;

    public static void StateChanged(GameState state)
    {
        OnStateChanged?.Invoke(state);
    }

    public static event Action OnPlayerDeath;

    public static void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public static event Action OnScorePointPassed;

    public static void ScorePointPassed()
    {
        OnScorePointPassed?.Invoke();
    }

}