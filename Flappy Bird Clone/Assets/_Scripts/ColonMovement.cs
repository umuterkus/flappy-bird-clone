using UnityEngine;

public class ColonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool isMoveable = true;


    private void OnEnable()
    {
        isMoveable = true;

        GameEvents.OnGameEnd += StopMovement;
    }

    private void OnDisable()
    {
        GameEvents.OnGameEnd -= StopMovement;
    }

    private void StopMovement()
    {
        isMoveable = false;
    }

    void Update()
    {
        if (!isMoveable) return;

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -8)
        {
            gameObject.SetActive(false);
        }
    }
}