using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Player 1")]
    public float player1Speed = 1000f;
    public float player1Height = 3f;
    public Color player1Color = Color.white;

    [Header("Player 2")]
    public float player2Speed = 1000f;
    public float player2Height = 3f;
    public Color player2Color = Color.white;

    [Header("Reglas del partido")]
    [Tooltip("Puntos necesarios para ganar (mejor de 5 = 3 puntos)")]
    public int pointsToWin = 3;

    [Tooltip("Segundos que la pelota puede estar de un lado antes de que sea gol automático")]
    public float goalTimeLimit = 20f;

    [ContextMenu("Reset to Defaults")]
    public void ResetToDefaults()
    {
        player1Speed = 1000f;
        player2Speed = 1000f;
        player1Height = 3f;
        player2Height = 3f;
        player1Color = Color.white;
        player2Color = Color.white;

        pointsToWin = 3;
        goalTimeLimit = 20f;
    }
}
