using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private KeyCode colorChange = KeyCode.R;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Color
        if (Input.GetKeyUp(colorChange))
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
    }
}
