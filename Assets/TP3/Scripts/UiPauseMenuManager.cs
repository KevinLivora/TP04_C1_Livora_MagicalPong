using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiPauseMenuManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private Move player1;
    [SerializeField] private Move player2;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Pause Menu Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnPauseSettings;
    [SerializeField] private Button btnPauseCredits;
    [SerializeField] private Button btnPauseQuit;

    [Header("Settings Panel")]
    [SerializeField] private Slider sliderP1Speed;
    [SerializeField] private Slider sliderP2Speed;
    [SerializeField] private TMP_Text textP1Speed;
    [SerializeField] private TMP_Text textP2Speed;
    [SerializeField] private Button btnBackSettings;

    [Header("Credits Panel")]
    [SerializeField] private Button btnBackCredits;

    [Header("Settings Panel - Height")]
    [SerializeField] private Slider sliderP1Height;
    [SerializeField] private Slider sliderP2Height;
    [SerializeField] private TMP_Text textP1Height;
    [SerializeField] private TMP_Text textP2Height;

    [Header("Settings Panel - Color")]
    [SerializeField] private Button btnP1Red, btnP1Blue, btnP1Green, btnP1Yellow;
    [SerializeField] private Button btnP2Red, btnP2Blue, btnP2Green, btnP2Yellow;

    private bool isPaused = false;
    private GameObject lastPanel;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnPauseSettings.onClick.AddListener(() => OpenPanel(settingsPanel, pausePanel));
        btnPauseCredits.onClick.AddListener(() => OpenPanel(creditsPanel, pausePanel));
        btnPauseQuit.onClick.AddListener(OnQuitClicked);

        btnBackSettings.onClick.AddListener(OnBackClicked);
        btnBackCredits.onClick.AddListener(OnBackClicked);

        sliderP1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged);
        sliderP2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);

        sliderP1Height.onValueChanged.AddListener(OnPlayer1HeightChanged);
        sliderP2Height.onValueChanged.AddListener(OnPlayer2HeightChanged);

        // --- Colores P1 ---
        btnP1Red.onClick.AddListener(() =>
        {
            GameSettings.player1Color = Color.red;
            if (player1 != null) player1.SetColor(Color.red);
        });
        btnP1Blue.onClick.AddListener(() =>
        {
            GameSettings.player1Color = Color.blue;
            if (player1 != null) player1.SetColor(Color.blue);
        });
        btnP1Green.onClick.AddListener(() =>
        {
            GameSettings.player1Color = Color.green;
            if (player1 != null) player1.SetColor(Color.green);
        });
        btnP1Yellow.onClick.AddListener(() =>
        {
            GameSettings.player1Color = Color.yellow;
            if (player1 != null) player1.SetColor(Color.yellow);
        });

        // --- Colores P2 ---
        btnP2Red.onClick.AddListener(() =>
        {
            GameSettings.player2Color = Color.red;
            if (player2 != null) player2.SetColor(Color.red);
        });
        btnP2Blue.onClick.AddListener(() =>
        {
            GameSettings.player2Color = Color.blue;
            if (player2 != null) player2.SetColor(Color.blue);
        });
        btnP2Green.onClick.AddListener(() =>
        {
            GameSettings.player2Color = Color.green;
            if (player2 != null) player2.SetColor(Color.green);
        });
        btnP2Yellow.onClick.AddListener(() =>
        {
            GameSettings.player2Color = Color.yellow;
            if (player2 != null) player2.SetColor(Color.yellow);
        });
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        sliderP1Speed.value = GameSettings.player1Speed;
        sliderP2Speed.value = GameSettings.player2Speed;
        textP1Speed.text = GameSettings.player1Speed.ToString("F0");
        textP2Speed.text = GameSettings.player2Speed.ToString("F0");

        sliderP1Height.value = GameSettings.player1Height;
        sliderP2Height.value = GameSettings.player2Height;
        textP1Height.text = GameSettings.player1Height.ToString("F1");
        textP2Height.text = GameSettings.player2Height.ToString("F1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnPauseSettings.onClick.RemoveAllListeners();
        btnPauseCredits.onClick.RemoveAllListeners();
        btnPauseQuit.onClick.RemoveAllListeners();

        btnBackSettings.onClick.RemoveAllListeners();
        btnBackCredits.onClick.RemoveAllListeners();

        sliderP1Speed.onValueChanged.RemoveAllListeners();
        sliderP2Speed.onValueChanged.RemoveAllListeners();

        sliderP1Height.onValueChanged.RemoveAllListeners();
        sliderP2Height.onValueChanged.RemoveAllListeners();

        btnP1Red.onClick.RemoveAllListeners();
        btnP1Blue.onClick.RemoveAllListeners();
        btnP1Green.onClick.RemoveAllListeners();
        btnP1Yellow.onClick.RemoveAllListeners();

        btnP2Red.onClick.RemoveAllListeners();
        btnP2Blue.onClick.RemoveAllListeners();
        btnP2Green.onClick.RemoveAllListeners();
        btnP2Yellow.onClick.RemoveAllListeners();
    }

    private void OnQuitClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    // --- Pausa ---

    private void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void OnContinueClicked()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // --- Settings / Credits ---

    private void OpenPanel(GameObject panelToOpen, GameObject callerPanel)
    {
        lastPanel = callerPanel;
        callerPanel.SetActive(false);
        panelToOpen.SetActive(true);
    }

    private void OnBackClicked()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        if (lastPanel != null)
            lastPanel.SetActive(true);
    }

    // --- Sliders ---

    private void OnPlayer1SpeedChanged(float value)
    {
        GameSettings.player1Speed = value;
        textP1Speed.text = value.ToString("F0");
        if (player1 != null) player1.moveSpeed = value;
    }

    private void OnPlayer2SpeedChanged(float value)
    {
        GameSettings.player2Speed = value;
        textP2Speed.text = value.ToString("F0");
        if (player2 != null) player2.moveSpeed = value;
    }

    // --- Height ---

    private void OnPlayer1HeightChanged(float value)
    {
        GameSettings.player1Height = value;
        textP1Height.text = value.ToString("F1");
        if (player1 != null) player1.SetHeight(value);
    }

    private void OnPlayer2HeightChanged(float value)
    {
        GameSettings.player2Height = value;
        textP2Height.text = value.ToString("F1");
        if (player2 != null) player2.SetHeight(value);
    }
}