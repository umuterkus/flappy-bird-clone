using System;
using UnityEngine;

public static class GameEvents
{

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
    
    public static event Action OnGameReset;
    public static void GameReset() => OnGameReset?.Invoke();

    public static event Action OnGameStart;
    public static void GameStart() => OnGameStart?.Invoke();

    public static event Action OnGameEnd;
    public static void GameEnd() => OnGameEnd?.Invoke();
}