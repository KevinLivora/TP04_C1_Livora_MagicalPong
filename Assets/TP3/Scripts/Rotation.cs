using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private KeyCode rotateRigth = KeyCode.Q;
    [SerializeField] private KeyCode rotateLeft = KeyCode.E;
    [SerializeField] private float rotateSpeed = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotacion 
        
        if (Input.GetKeyDown(rotateRigth))
        {
            // Fuerza continua:
            rb.AddTorque(rotateSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(rotateLeft))
        {
            rb.AddTorque(-rotateSpeed, ForceMode2D.Impulse);
        }
    }
}
