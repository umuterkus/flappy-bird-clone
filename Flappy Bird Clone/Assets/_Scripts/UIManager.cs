using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Paneller")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject waitScreenPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject gameOverPanel; 
    private void OnEnable()
    {
 
        GameEvents.OnStateChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameEvents.OnStateChanged -= UpdateUI;
    }

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


    private void UpdateUI(GameState newState)
    {
 
        mainMenuPanel.SetActive(false);
        waitScreenPanel.SetActive(false);
        if (inGamePanel != null) inGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        switch (newState)
        {
            case GameState.MainMenu:
                mainMenuPanel.SetActive(true);
                break;

            case GameState.WaitScreen:
                waitScreenPanel.SetActive(true); 
                break;

            case GameState.Playing:
                if (inGamePanel) inGamePanel.SetActive(true);
                break;

            case GameState.GameOverScreen:
                gameOverPanel.SetActive(true); 
                break;
        }
    }


    public void PlayButtonPressed()
    {

        GameManager.Instance.StartGameSequence();
    }

    public void OnRestartButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }


    public void OnMainMenuButtonClicked()
    {
        GameManager.Instance.GoToMainMenu();
    }
}