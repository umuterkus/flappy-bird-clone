using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isInputEnabled = false;
    private Vector3 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        SetPhysicsActive(false);
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += DisableMovement;

        // EKLEDÝÐÝM KISIM: Durum deðiþikliðini dinle
        GameEvents.OnStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= DisableMovement;

        // EKLEDÝÐÝM KISIM: Abonelikten çýk
        GameEvents.OnStateChanged -= OnGameStateChanged;
    }

    // EKLEDÝÐÝM KISIM: GameManager "Playing" dediðinde senin fonksiyonunu çalýþtýrýr
    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.Playing)
        {
            EnableMovement();
        }
        else if (state == GameState.MainMenu || state == GameState.WaitScreen)
        {
            ResetPlayer();
        }
    }

    void Update()
    {
        if (!isInputEnabled) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    public void EnableMovement()
    {
        isInputEnabled = true;
        SetPhysicsActive(true);

        rb.linearVelocity = Vector2.up * jumpForce;
        Debug.Log("Player: Hareket Aktif!");
    }

    public void DisableMovement()
    {
        isInputEnabled = false;
        SetPhysicsActive(false);
        Debug.Log("Player: Hareket Pasif.");
    }

    public void ResetPlayer()
    {
        isInputEnabled = false;
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rb.linearVelocity = Vector2.zero;
        SetPhysicsActive(false);
        Debug.Log("Player: Resetlendi.");
    }

    private void SetPhysicsActive(bool isActive)
    {
        rb.simulated = isActive;
    }
}