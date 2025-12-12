using UnityEngine;

public class ColourFilter : MonoBehaviour
{

    public Color filterColor = Color.red;
    public SpriteRenderer filterSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (filterSprite == null)
        {
            filterSprite = GetComponent<SpriteRenderer>();
        }

        filterSprite.color = filterColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLightController player = collision.GetComponent<PlayerLightController>();

            if (player != null)
            {
                player.currentLightColour = filterColor;
                player.playerLight.color = filterColor;
                Debug.Log("Player entered colour filter: " + filterColor.ToString());
            }
        }
    }
}
