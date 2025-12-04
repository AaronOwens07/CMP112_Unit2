using UnityEngine;

public class RevealableMaterial : MonoBehaviour
{
    public float revealSpeed = 1.0f;
    public Color revealColour;
    public Color hiddenColour;

    private SpriteRenderer spriteRenderer;
    public bool isRevealed = false;
    public float revealProgress = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize the sprite renderer and set initial material properties
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = hiddenColour;
        spriteRenderer.material.SetFloat("_RevealAmount", 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isRevealed && revealProgress < 1.0f)
        {
            revealProgress += Time.deltaTime * revealSpeed;
            spriteRenderer.color = Color.Lerp(hiddenColour, revealColour, revealProgress);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRevealed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //isRevealed = false;
           // revealProgress = 0.0f;
           // spriteRenderer.color = hiddenColour;
           // spriteRenderer.material.SetFloat("_RevealAmount", 0.0f);
        }
    }
}
