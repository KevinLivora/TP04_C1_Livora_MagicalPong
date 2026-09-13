using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    [Header("Config")]
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Ball ball;
    [SerializeField] private Move player1;
    [SerializeField] private Move player2;

    [Header("UI - Cuenta regresiva")]
    [SerializeField] private TMP_Text textCountdown;
    [SerializeField] private float countdownSeconds = 3f;

    [Header("UI - Marcador")]
    [SerializeField] private TMP_Text textScoreP1;
    [SerializeField] private TMP_Text textScoreP2;

    [Header("UI - Fin de partido")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text textWinner;
    [SerializeField] private Button btnPlayAgain;
    [SerializeField] private Button btnBackToMenu;

    private int scoreP1;
    private int scoreP2;
    private bool matchOver;

    private void Awake()
    {
        Instance = this;

        btnPlayAgain?.onClick.AddListener(OnPlayAgainClicked);
        btnBackToMenu?.onClick.AddListener(OnBackToMenuClicked);
    }

    private void OnDestroy()
    {
        btnPlayAgain?.onClick.RemoveAllListeners();
        btnBackToMenu?.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        matchOver = false;

        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false);

        StartCoroutine(StartRound());
    }

    public void OnGoalScored(int scoringPlayer)
    {
        if (matchOver) return;

        if (scoringPlayer == 1) scoreP1++;
        else scoreP2++;

        UpdateScoreUI();

        if (scoreP1 >= gameSettings.pointsToWin || scoreP2 >= gameSettings.pointsToWin)
        {
            EndMatch(scoreP1 > scoreP2 ? 1 : 2);
        }
        else
        {
            StartCoroutine(StartRound());
        }
    }

    private void UpdateScoreUI()
    {
        if (textScoreP1 != null) textScoreP1.text = scoreP1.ToString();
        if (textScoreP2 != null) textScoreP2.text = scoreP2.ToString();
    }

    private IEnumerator StartRound()
    {
        player1.ResetPosition();
        player2.ResetPosition();
        ball.ResetToCenter();

        float remaining = countdownSeconds;

        if (textCountdown != null)
            textCountdown.gameObject.SetActive(true);

        while (remaining > 0f)
        {
            if (textCountdown != null)
                textCountdown.text = Mathf.CeilToInt(remaining).ToString();

            yield return new WaitForSeconds(1f);
            remaining -= 1f;
        }

        if (textCountdown != null)
            textCountdown.gameObject.SetActive(false);

        ball.Launch();
    }

    private void EndMatch(int winningPlayer)
    {
        matchOver = true;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            if (textWinner != null)
                textWinner.text = $"¡Jugador {winningPlayer} gana!";
        }
    }

    // --- End Game Buttons ---

    private void OnPlayAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnBackToMenuClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
