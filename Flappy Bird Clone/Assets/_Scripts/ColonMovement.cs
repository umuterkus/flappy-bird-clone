using UnityEngine;

public class ColonMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector3 (-1 * moveSpeed, 0, 0));
        
    }
}
