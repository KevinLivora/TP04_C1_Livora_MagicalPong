using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Players (opcional)")]
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

    private void Awake()
    {
        sliderP1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged);
        sliderP2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);
        sliderP1Height.onValueChanged.AddListener(OnPlayer1HeightChanged);
        sliderP2Height.onValueChanged.AddListener(OnPlayer2HeightChanged);

        btnP1Red.onClick.AddListener(() => { GameSettings.player1Color = Color.red; if (player1 != null) player1.SetColor(Color.red); });
        btnP1Blue.onClick.AddListener(() => { GameSettings.player1Color = Color.blue; if (player1 != null) player1.SetColor(Color.blue); });
        btnP1Green.onClick.AddListener(() => { GameSettings.player1Color = Color.green; if (player1 != null) player1.SetColor(Color.green); });
        btnP1Yellow.onClick.AddListener(() => { GameSettings.player1Color = Color.yellow; if (player1 != null) player1.SetColor(Color.yellow); });

        btnP2Red.onClick.AddListener(() => { GameSettings.player2Color = Color.red; if (player2 != null) player2.SetColor(Color.red); });
        btnP2Blue.onClick.AddListener(() => { GameSettings.player2Color = Color.blue; if (player2 != null) player2.SetColor(Color.blue); });
        btnP2Green.onClick.AddListener(() => { GameSettings.player2Color = Color.green; if (player2 != null) player2.SetColor(Color.green); });
        btnP2Yellow.onClick.AddListener(() => { GameSettings.player2Color = Color.yellow; if (player2 != null) player2.SetColor(Color.yellow); });
    }

    private void Start()
    {
        sliderP1Speed.value = GameSettings.player1Speed;
        sliderP2Speed.value = GameSettings.player2Speed;
        textP1Speed.text = GameSettings.player1Speed.ToString("F0");
        textP2Speed.text = GameSettings.player2Speed.ToString("F0");

        sliderP1Height.value = GameSettings.player1Height;
        sliderP2Height.value = GameSettings.player2Height;
        textP1Height.text = GameSettings.player1Height.ToString("F1");
        textP2Height.text = GameSettings.player2Height.ToString("F1");
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
    }

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