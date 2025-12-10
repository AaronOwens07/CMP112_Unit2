using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public string activatedByTag;
    private SpriteRenderer spriteRenderer;

    public Sprite deactivatedSprite;
    public Sprite activatedSprite;

    public GameObject activatedObject;
    public GameObject secondActivatedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deactivatedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activatedByTag))
        {
            // Logic for when the pressure plate is activated
            Debug.Log("Pressure Plate Activated by " + activatedByTag);
            spriteRenderer.sprite = activatedSprite;
            if (activatedObject != null)
            {
                activatedObject.SetActive(false);
                secondActivatedObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Pressure Plate not activated. Collided with " + collision.gameObject.tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activatedByTag))
        {
            // Logic for when the pressure plate is deactivated
            Debug.Log("Pressure Plate Deactivated by " + activatedByTag);
            spriteRenderer.sprite = deactivatedSprite;
            if (activatedObject != null)
            {
                activatedObject.SetActive(true);
                secondActivatedObject.SetActive(false);
            }
        }
    }
}
