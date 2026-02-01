using UnityEngine;
using DG.Tweening;

public class Ground : MonoBehaviour, ICollidable
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float groundSize = 20f;

    private Tween moveTween;
    private void Start()
    {
        StartInfiniteMovement();
    }
    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += OnPlayerDeath;
        GameEvents.OnGameReset += OnGameReset;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= OnPlayerDeath;
        moveTween?.Kill();
    }

    private void OnGameReset()
    {
        moveTween?.Play();
    }
    private void OnPlayerDeath()
    {
        moveTween?.Pause();
    }
    private void StartInfiniteMovement()
    {
        float duration = groundSize / moveSpeed;
        float targetX = transform.position.x - groundSize;

        moveTween = transform.DOMoveX(targetX, duration)
            .SetEase(Ease.Linear)         
            .SetLoops(-1, LoopType.Restart); 
    }

    public void OnPlayerHit()
    {
        Debug.Log("Game Over");   
    }
}