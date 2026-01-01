
using UnityEngine;
using UnityEngine.UIElements;

public class ColonMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector3 (-1 * moveSpeed * Time.deltaTime, 0, 0));

        if(rb.transform.position.x < -8)
        {
            gameObject.SetActive(false);



        }
        
    }
}
