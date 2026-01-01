using UnityEngine;

public class ScoreZone : MonoBehaviour , ICollidable
{
    public void OnPlayerHit()
    {
        GameEvents.ScorePointPassed();
        
    }
}
