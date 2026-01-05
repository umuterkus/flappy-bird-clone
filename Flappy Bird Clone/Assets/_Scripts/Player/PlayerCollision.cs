using System;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    

    bool isDead = false;

    private void OnEnable()
    {
        GameEvents.OnGameReset += RevivePlayer;
    }

    private void OnDisable()
    {
        GameEvents.OnGameReset -= RevivePlayer;
    }

    private void RevivePlayer()
    {
        isDead = false;
    }

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
            hitObject.OnPlayerHit();
        }
    }

    private void Die()
    {
       
        isDead = true;
        GameEvents.PlayerDeath();
    }

}
