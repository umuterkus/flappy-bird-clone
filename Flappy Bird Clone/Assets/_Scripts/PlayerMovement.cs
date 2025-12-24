using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpForce = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(0, 1 * jumpForce);
            
        }

    }
}
