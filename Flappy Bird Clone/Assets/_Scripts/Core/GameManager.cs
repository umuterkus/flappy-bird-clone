using UnityEngine;
using UnityEngine.SceneManagement;

// Enum'ý en üste veya ayrý bir dosyaya koyabilirsin
public enum GameState
{
    MainMenu,
    WaitScreen,
    Playing,
    GameOverScreen,
    PauseMenu
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        // Singleton Yapýsý
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Oyunu Main Menu ile baþlatýyoruz
        ChangeState(GameState.MainMenu);
    }

    private void OnEnable()
    {
        // Sadece ölümü dinlememiz yeterli, çünkü ölüm state deðiþtirir.
        GameEvents.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        if (CurrentState == GameState.Playing)
        {
            ChangeState(GameState.GameOverScreen);
        }
    }
    public void StartGameSequence()
    {
        ChangeState(GameState.WaitScreen);
    }

    public void ConfirmStartGame()
    {
        if (CurrentState == GameState.WaitScreen)
        {
            ChangeState(GameState.Playing);
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;


        GameEvents.StateChanged(newState);

        switch (newState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                break;

            case GameState.WaitScreen:
                Time.timeScale = 1f;
                Debug.Log("Durum: Bekleniyor... Týkla Baþla");
                break;

            case GameState.Playing:
                Time.timeScale = 1f;
                Debug.Log("Durum: Oyun Oynanýyor");
                break;

            case GameState.GameOverScreen:
                Time.timeScale = 0f;
                Debug.Log("Durum: Oyun Bitti");
                break;

            case GameState.PauseMenu:
                Time.timeScale = 0f;
                Debug.Log("Game Paused");
                break;
        }
    }

    public void TogglePauseGame()
    {
        if (CurrentState == GameState.Playing)
        {
            ChangeState(GameState.PauseMenu);
        }
        else if (CurrentState == GameState.PauseMenu)
        {
            ChangeState(GameState.Playing);
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Sahne yüklemeden önce zamaný düzeltmek önemlidir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}