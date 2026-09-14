using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int scoringPlayer = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball == null) return;

        MatchManager.Instance.OnGoalScored(scoringPlayer);
    }
}
