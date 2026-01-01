using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Paneller")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject waitScreenPanel;
    [SerializeField] private GameObject inGamePanel; // Skor vb. oyun içi UI için (Opsiyonel)

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

        // 2. Duruma uygun paneli aç
        switch (newState)
        {
            case GameState.MainMenu:
                mainMenuPanel.SetActive(true);
                break;

            case GameState.WaitScreen:
                waitScreenPanel.SetActive(true);
                break;

            case GameState.Playing:
                if (inGamePanel != null) inGamePanel.SetActive(true);
                break;

                // GameOver durumunu eklemek istersen buraya case açabilirsin
        }
    }

    // === BUTON FONKSÝYONLARI ===

    // Main Menu'deki "PLAY" butonunun OnClick kýsmýna bunu baðla
    public void PlayButtonPressed()
    {
        // GameManager'a "Wait Screen'e geçiþ yap" emrini iletiyoruz
        GameManager.Instance.StartGameSequence();
    }
}