using UnityEngine;

public class SecondActivatedObject : MonoBehaviour
{
    public string activatedByTag;
    public GameObject secondActivatedObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activatedByTag))
        {

            if (secondActivatedObject != null)
            {
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

            if (secondActivatedObject != null)
            {
                secondActivatedObject.SetActive(false);
            }
        }
    }
}
