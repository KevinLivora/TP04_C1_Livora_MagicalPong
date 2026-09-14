using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameSettings gameSettings;
    public float moveSpeed = 1000f;
    private Rigidbody2D rb;

    public bool isPlayerOne = true;
    private Vector3 initialPosition;
    private bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        initialPosition = transform.position;
    }

    private void Start()
    {
        moveSpeed = isPlayerOne ? gameSettings.player1Speed : gameSettings.player2Speed;
        SetHeight(isPlayerOne ? gameSettings.player1Height : gameSettings.player2Height);
        SetColor(isPlayerOne ? gameSettings.player1Color : gameSettings.player2Color);
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        if (Input.GetKey(moveUp))
            rb.AddForce(new Vector2(0, moveSpeed * Time.fixedDeltaTime));

        if (Input.GetKey(moveRight))
            rb.AddForce(new Vector2(moveSpeed * Time.fixedDeltaTime, 0));

        if (Input.GetKey(moveDown))
            rb.AddForce(new Vector2(0, -moveSpeed * Time.fixedDeltaTime));

        if (Input.GetKey(moveLeft))
            rb.AddForce(new Vector2(-moveSpeed * Time.fixedDeltaTime, 0));
    }

    public void SetHeight(float height)
    {
        transform.localScale = new Vector3(transform.localScale.x, height, 1f);
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        rb.linearVelocity = Vector2.zero;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ball>() != null)
        {
            SetColor(new Color(Random.value, Random.value, Random.value));
            return;
        }

        if (collision.collider.CompareTag("Limit"))
        {
            SetColor(Color.black);
        }
    }
}