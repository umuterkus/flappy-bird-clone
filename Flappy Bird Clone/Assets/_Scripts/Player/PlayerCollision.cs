using System;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public event Action OnBirdDied;
    public event Action OnScoreGained;

    bool isDead = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.TryGetComponent(out ICollidable hitObject))
        {
            hitObject.OnPlayerHit();
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.TryGetComponent(out ICollidable hitObject)) 
        {
            
            OnScoreGained?.Invoke();
        }
    }

    private void Die()
    {
        isDead = true;
        
        OnBirdDied?.Invoke();
    }

}
