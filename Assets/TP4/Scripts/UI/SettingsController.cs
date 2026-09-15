using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Game Settings (asset)")]
    [SerializeField] private GameSettings gameSettings;

    [Header("Players")]
    [SerializeField] private Move player1;
    [SerializeField] private Move player2;

    [Header("Speed")]
    [SerializeField] private Slider sliderP1Speed;
    [SerializeField] private Slider sliderP2Speed;
    [SerializeField] private TMP_Text textP1Speed;
    [SerializeField] private TMP_Text textP2Speed;

    [Header("Height")]
    [SerializeField] private Slider sliderP1Height;
    [SerializeField] private Slider sliderP2Height;
    [SerializeField] private TMP_Text textP1Height;
    [SerializeField] private TMP_Text textP2Height;

    [Header("Color")]
    [SerializeField] private Button btnP1Red, btnP1Blue, btnP1Green, btnP1Yellow;
    [SerializeField] private Button btnP2Red, btnP2Blue, btnP2Green, btnP2Yellow;

    [Header("Match Settings")]
    [SerializeField] private GameObject matchSettingsSection;
    [SerializeField] private Button btnBestOf3;
    [SerializeField] private Button btnBestOf5;
    [SerializeField] private Button btnBestOf7;
    [SerializeField] private TMP_Text textPointsToWin;
    [SerializeField] private Slider sliderGoalTime;
    [SerializeField] private TMP_Text textGoalTime;

    private const int MinGoalTime = 15;
    private const int MaxGoalTime = 40;

    private void Awake()
    {
        sliderP1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged);
        sliderP2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);
        sliderP1Height.onValueChanged.AddListener(OnPlayer1HeightChanged);
        sliderP2Height.onValueChanged.AddListener(OnPlayer2HeightChanged);

        btnP1Red.onClick.AddListener(() => { gameSettings.player1Color = Color.red; if (player1 != null) player1.SetColor(Color.red); });
        btnP1Blue.onClick.AddListener(() => { gameSettings.player1Color = Color.blue; if (player1 != null) player1.SetColor(Color.blue); });
        btnP1Green.onClick.AddListener(() => { gameSettings.player1Color = Color.green; if (player1 != null) player1.SetColor(Color.green); });
        btnP1Yellow.onClick.AddListener(() => { gameSettings.player1Color = Color.yellow; if (player1 != null) player1.SetColor(Color.yellow); });

        btnP2Red.onClick.AddListener(() => { gameSettings.player2Color = Color.red; if (player2 != null) player2.SetColor(Color.red); });
        btnP2Blue.onClick.AddListener(() => { gameSettings.player2Color = Color.blue; if (player2 != null) player2.SetColor(Color.blue); });
        btnP2Green.onClick.AddListener(() => { gameSettings.player2Color = Color.green; if (player2 != null) player2.SetColor(Color.green); });
        btnP2Yellow.onClick.AddListener(() => { gameSettings.player2Color = Color.yellow; if (player2 != null) player2.SetColor(Color.yellow); });

        if (matchSettingsSection != null)
        {
            btnBestOf3.onClick.AddListener(() => SetPointsToWin(2));
            btnBestOf5.onClick.AddListener(() => SetPointsToWin(3));
            btnBestOf7.onClick.AddListener(() => SetPointsToWin(4));
            sliderGoalTime.onValueChanged.AddListener(OnGoalTimeChanged);
        }
    }

    private void Start()
    {
        sliderP1Speed.value = gameSettings.player1Speed;
        sliderP2Speed.value = gameSettings.player2Speed;
        textP1Speed.text = gameSettings.player1Speed.ToString("F0");
        textP2Speed.text = gameSettings.player2Speed.ToString("F0");

        sliderP1Height.value = gameSettings.player1Height;
        sliderP2Height.value = gameSettings.player2Height;
        textP1Height.text = gameSettings.player1Height.ToString("F1");
        textP2Height.text = gameSettings.player2Height.ToString("F1");

        if (matchSettingsSection != null)
        {
            bool isMainMenu = player1 == null && player2 == null;
            matchSettingsSection.SetActive(isMainMenu);

            if (isMainMenu)
            {
                sliderGoalTime.minValue = MinGoalTime;
                sliderGoalTime.maxValue = MaxGoalTime;
                sliderGoalTime.wholeNumbers = true;
                sliderGoalTime.value = gameSettings.goalTimeLimit;
                textGoalTime.text = gameSettings.goalTimeLimit.ToString("F0") + "s";

                UpdatePointsToWinText();
            }
        }
    }
    private void OnDestroy()
    {
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

        if (matchSettingsSection != null)
        {
            btnBestOf3.onClick.RemoveAllListeners();
            btnBestOf5.onClick.RemoveAllListeners();
            btnBestOf7.onClick.RemoveAllListeners();
            sliderGoalTime.onValueChanged.RemoveAllListeners();
        }
    }

    private void OnPlayer1SpeedChanged(float value)
    {
        gameSettings.player1Speed = value;
        textP1Speed.text = value.ToString("F0");
        if (player1 != null) player1.moveSpeed = value;
    }

    private void OnPlayer2SpeedChanged(float value)
    {
        gameSettings.player2Speed = value;
        textP2Speed.text = value.ToString("F0");
        if (player2 != null) player2.moveSpeed = value;
    }

    private void OnPlayer1HeightChanged(float value)
    {
        gameSettings.player1Height = value;
        textP1Height.text = value.ToString("F1");
        if (player1 != null) player1.SetHeight(value);
    }

    private void OnPlayer2HeightChanged(float value)
    {
        gameSettings.player2Height = value;
        textP2Height.text = value.ToString("F1");
        if (player2 != null) player2.SetHeight(value);
    }

    private void SetPointsToWin(int points)
    {
        gameSettings.pointsToWin = points;
        UpdatePointsToWinText();
    }

    private void UpdatePointsToWinText()
    {
        int bestOf = gameSettings.pointsToWin * 2 - 1; 
        textPointsToWin.text = $"Mejor de {bestOf} (a {gameSettings.pointsToWin})";
    }

    private void OnGoalTimeChanged(float value)
    {
        gameSettings.goalTimeLimit = value;
        textGoalTime.text = value.ToString("F0") + "s";
    }
}