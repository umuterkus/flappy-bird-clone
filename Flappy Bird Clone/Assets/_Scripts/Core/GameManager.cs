using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    [SerializeField] private GameObject playerObject;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    { 
        ChangeState(GameState.MainMenu);
    }

    private void OnEnable()
    {
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

    public void RestartGame()
    {
        ChangeState(GameState.WaitScreen);
    }

    public void GoToMainMenu()
    {
        ChangeState(GameState.MainMenu);
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
                GameEvents.GameReset();
                break;

            case GameState.Playing:
                Time.timeScale = 1f;
                GameEvents.GameStart();
                Debug.Log("Durum: Oyun Oynanýyor");
                break;

            case GameState.GameOverScreen:
                Time.timeScale = 1f;
                GameEvents.GameEnd();
                Debug.Log("Durum: Oyun Bitti");
                break;
        }
    }

  

}