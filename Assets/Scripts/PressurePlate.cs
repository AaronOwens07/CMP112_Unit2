using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public string activatedByTag;
    private SpriteRenderer spriteRenderer;
    public Color deactivatedColour = Color.red;
    public Color activatedColour = Color.green;

    public GameObject activatedObject;
    public GameObject secondActivatedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = deactivatedColour;
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
            spriteRenderer.color = activatedColour;
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
            spriteRenderer.color = deactivatedColour;
            if (activatedObject != null)
            {
                activatedObject.SetActive(true);
                secondActivatedObject.SetActive(false);
            }
        }
    }
}
