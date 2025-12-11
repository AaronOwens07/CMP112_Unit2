using UnityEngine;
using UnityEngine.Tilemaps;

public class RevealableTileMap : MonoBehaviour
{
    public float revealSpeed = 1.0f;
    public Color revealColour;
    public Color hiddenColour;

    private Tilemap tilemapRenderer;
    public bool isRevealed = false;
    public float revealProgress = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize the sprite renderer and set initial material properties
        tilemapRenderer = GetComponent<Tilemap>();
        tilemapRenderer.color = hiddenColour;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRevealed && revealProgress < 1.0f)
        {
            revealProgress += Time.deltaTime * revealSpeed;
            tilemapRenderer.color = Color.Lerp(hiddenColour, revealColour, revealProgress);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isRevealed = true;
        }
    }

}


