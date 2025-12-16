using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public string activatedByTag;
    private SpriteRenderer spriteRenderer;

    public Sprite deactivatedSprite;
    public Sprite activatedSprite;

    public GameObject activatedObject;

    public AudioSource pressurePlateSound;

    public bool isPressed = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activatedByTag))
        {
            pressurePlateSound.Play();
        }
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
                

            }
            isPressed = true;
            
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
                
            }
            isPressed = false;
        }
    }
}
