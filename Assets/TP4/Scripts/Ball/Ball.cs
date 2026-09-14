using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 500f;
    [SerializeField] private float speedIncreaseOnHit = 1.1f;
    [SerializeField] private float maxSpeed = 5000f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetToCenter()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;
    }

    public void Launch()
    {
        float dirX = Random.value < 0.5f ? -1f : 1f;
        float dirY = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(dirX, dirY).normalized;
        rb.AddForce(direction * initialSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Move>() == null) return;

        Vector2 velocity = rb.linearVelocity * speedIncreaseOnHit;
        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        rb.linearVelocity = velocity;
    }
}
