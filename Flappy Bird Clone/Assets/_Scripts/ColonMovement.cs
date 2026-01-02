
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ColonMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    
    Rigidbody2D rb;
    private bool isMoveable = true;

    private void OnEnable()
    {
        GameEvents.OnStateChanged += HandleStateChanged;
    }

    

    private void OnDisable()
    {
        GameEvents.OnStateChanged -= HandleStateChanged;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void HandleStateChanged(GameState state)
    {
        if (state == GameState.GameOverScreen)
        {
            isMoveable = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isMoveable) return;
        rb.transform.Translate(new Vector3 (-1 * moveSpeed * Time.deltaTime, 0, 0));

        if(rb.transform.position.x < -8)
        {
            gameObject.SetActive(false);



        }
        
    }
}
