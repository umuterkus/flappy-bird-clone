using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpDuration = 0.15f; 
    [SerializeField] private float fallDuration = 0.8f;  
    [SerializeField] private float upRotate = 25f;
    [SerializeField] private float downRotate = 90f;
    
    private Rigidbody2D rb;
    private bool isInputEnabled = false;
    private Vector3 initialPosition;
    private Vector3 defaultScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        defaultScale = transform.localScale; 

        
        isInputEnabled = false;
        SetPhysicsActive(false);
    }

    void Update()
    {
        if (!isInputEnabled) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }
    private void OnEnable()
    {

        GameEvents.OnGameReset += ResetAndShowCharacter;
        GameEvents.OnGameStart += EnableMovement;
        GameEvents.OnGameEnd += DisableMovement;
    }

    private void OnDisable()
    {
        GameEvents.OnGameReset -= ResetAndShowCharacter;
        GameEvents.OnGameStart -= EnableMovement;
        GameEvents.OnGameEnd -= DisableMovement;
    }

    private void ResetAndShowCharacter()
    {
        transform.DOKill(); 
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rb.linearVelocity = Vector2.zero; 

        isInputEnabled = false;
        SetPhysicsActive(false);


        transform.localScale = Vector3.zero; 
        transform.DOScale(defaultScale, 0.5f).SetEase(Ease.OutBack); 
    }

 
    private void ExitToMenu()
    {
        isInputEnabled = false;
        SetPhysicsActive(false);
        transform.DOKill();


        transform.DOScale(Vector3.zero, 0.3f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
           
                gameObject.SetActive(false);
            });
    }

    private void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;

        transform.DOKill(); 


        transform.DORotate(new Vector3(0, 0, upRotate), jumpDuration)
            .OnComplete(() =>
            {
        
                transform.DORotate(new Vector3(0, 0, -downRotate), fallDuration)
                    .SetEase(Ease.InQuad);
            });
    }
    private void EnableMovement()
    {
        isInputEnabled = true;
        SetPhysicsActive(true);
        Jump(); 
    }
    public void DisableMovement()
    {
        isInputEnabled = false;
       
        SetPhysicsActive(true);
        transform.DOKill();
    }

    private void SetPhysicsActive(bool isActive)
    {
        rb.simulated = isActive;
    }
}