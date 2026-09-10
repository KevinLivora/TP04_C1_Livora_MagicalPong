using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float moveSpeed = 1000f;
    private Rigidbody2D rb;
    public bool isContinuous = true;

    public bool isPlayerOne = true; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    if (spriteRenderer == null)
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
        {
            moveSpeed = isPlayerOne ? GameSettings.player1Speed : GameSettings.player2Speed;
            SetHeight(isPlayerOne ? GameSettings.player1Height : GameSettings.player2Height);
            SetColor(isPlayerOne ? GameSettings.player1Color : GameSettings.player2Color);
        }

    private void FixedUpdate() // Físicas
    {
        // Movimiento
        if (isContinuous)
        {
            if (Input.GetKey(moveUp))
                rb.AddForce(new Vector3(0, moveSpeed * Time.fixedDeltaTime));

            if (Input.GetKey(moveRight))
                rb.AddForce(new Vector3(moveSpeed * Time.fixedDeltaTime, 0));

            if (Input.GetKey(moveDown))
                rb.AddForce(new Vector3(0, -moveSpeed * Time.fixedDeltaTime));

            if (Input.GetKey(moveLeft))
                rb.AddForce(new Vector3(-moveSpeed * Time.fixedDeltaTime, 0));   
        }
        else
        {
            if (Input.GetKey(moveUp))
                rb.position += new Vector2(0, moveSpeed * Time.fixedDeltaTime);

            if (Input.GetKey(moveRight))
                rb.position += new Vector2(moveSpeed * Time.fixedDeltaTime, 0);

            if (Input.GetKey(moveDown))
                rb.position += new Vector2(0, -moveSpeed * Time.fixedDeltaTime);

            if (Input.GetKey(moveLeft))
                rb.position += new Vector2(-moveSpeed * Time.fixedDeltaTime, 0);
        }
    }
    public void SetHeight(float height)
    {
        transform.localScale = new Vector3(transform.localScale.x, height, 1f);
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
