using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Paneller")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject waitScreenPanel;
    [SerializeField] private GameObject inGamePanel; // Skor vb. oyun içi UI için (Opsiyonel)
    [SerializeField] private GameObject gameOverPanel; // Bunu Inspector'da atamayý unutma!
    private void OnEnable()
    {
        // GameManager'dan gelen "Durum Deðiþti" anonsunu dinle
        GameEvents.OnStateChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameEvents.OnStateChanged -= UpdateUI;
    }

    private void Update()
    {
        // Sadece WaitScreen (Bekleme) durumundaysak týklamayý dinle
        if (GameManager.Instance.CurrentState == GameState.WaitScreen)
        {
            // Ekrana dokunulduðunda (Mobil ve PC uyumlu)
            if (Input.GetMouseButtonDown(0))
            {
                // GameManager'a "Artýk oyunu baþlatabilirsin" diyoruz
                GameManager.Instance.ConfirmStartGame();
            }
        }
    }

    // Event çalýþtýðýnda bu fonksiyon devreye girer
    private void UpdateUI(GameState newState)
    {
        // 1. Önce temizlik: Tüm panelleri kapat
        mainMenuPanel.SetActive(false);
        waitScreenPanel.SetActive(false);
        if (inGamePanel != null) inGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        // 2. Duruma uygun paneli aç
        switch (newState)
        {
            case GameState.MainMenu:
                mainMenuPanel.SetActive(true);
                break;

            case GameState.WaitScreen:
                waitScreenPanel.SetActive(true); // Restart yapýnca burasý açýlacak
                break;

            case GameState.Playing:
                if (inGamePanel) inGamePanel.SetActive(true);
                break;

            case GameState.GameOverScreen:
                gameOverPanel.SetActive(true); // Oyun bitince burasý açýlacak
                break;
        }
    }

    // === BUTON FONKSÝYONLARI ===

    // Main Menu'deki "PLAY" butonunun OnClick kýsmýna bunu baðla
    public void PlayButtonPressed()
    {
        // GameManager'a "Wait Screen'e geçiþ yap" emrini iletiyoruz
        GameManager.Instance.StartGameSequence();
    }

    public void OnRestartButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }

    // Main Menu butonuna baðlanacak fonksiyon
    public void OnMainMenuButtonClicked()
    {
        GameManager.Instance.GoToMainMenu();
    }
}