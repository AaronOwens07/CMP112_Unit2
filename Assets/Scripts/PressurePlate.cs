using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public string activatedByTag;
    private SpriteRenderer spriteRenderer;
    public Color deactivatedColour = Color.red;
    public Color activatedColour = Color.green;

    public GameObject activatedObject;

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
            }
        }
        else
        {
            Debug.Log("Pressure Plate not activated. Collided with " + collision.gameObject.tag);
        }
    }
}
