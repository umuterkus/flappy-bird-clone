using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.WaitScreen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.ConfirmStartGame();
            }
        }
    }
}
