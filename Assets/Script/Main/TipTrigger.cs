using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isTrigger(other))
        {
            spriteRenderer.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (isTrigger(other))
        {
            spriteRenderer.enabled = false;
        }
    }

    bool isTrigger(Collider2D other)
    {
        return other.gameObject.CompareTag("Cursor") || other.gameObject.CompareTag("Player");
    }
}