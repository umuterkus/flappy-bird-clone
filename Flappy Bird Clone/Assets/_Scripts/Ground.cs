using UnityEngine;

public class Ground : MonoBehaviour, ICollidable
{
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private float groundSize = 20f;

    private Vector3 startTransform;

    
    private bool isMoveable = true;

    private void OnEnable()
    {
        GameEvents.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnStateChanged -= HandleStateChanged;
    }

    private void Start()
    {
        startTransform = transform.position;
    }
    private void HandleStateChanged(GameState state)
    {
        if (state == GameState.GameOverScreen)
        {
            isMoveable = false;

        }
    }
    private void Update()
    {
        if (!isMoveable) { return;  }
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

        if (transform.position.x < startTransform.x - groundSize)
        {
            TeleportGround();
        }
    }

    private void TeleportGround()
    {
      
        transform.position = startTransform;
    }

    public void OnPlayerHit()
    {
    }
}