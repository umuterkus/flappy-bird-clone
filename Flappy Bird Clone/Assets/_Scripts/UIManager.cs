using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UIPanels")]
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
                gameOverPanel.transform.localScale = Vector3.zero;
                gameOverPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
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