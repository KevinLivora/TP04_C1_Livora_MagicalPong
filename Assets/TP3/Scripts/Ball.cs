using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 500f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Launch();
    }

    public void Launch()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;

        float dirX = Random.value < 0.5f ? -1f : 1f;
        float dirY = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(dirX, dirY).normalized;
        rb.AddForce(direction * initialSpeed);
    }
}