using UnityEngine;

public class ColonColider : MonoBehaviour, ICollidable
{
    public void OnPlayerHit()
    {
        Debug.Log("Game Over!");
    }
}
