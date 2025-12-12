using UnityEngine;

public class ColourBox : MonoBehaviour
{
    [Header("Box Settings")]
    public RevealableMaterial revealableMaterial;
    public Rigidbody2D rb;
    public bool canMove;
    public SpriteRenderer boxSprite;
    public GameObject player;
    public BoxCollider2D boxCollider;
    public float pushforce = 5f;
    public bool collisionChck;

    [Header("Colour Settings")]
    public Color boxColour;
    public Color requiredLightColour;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (boxSprite == null)
        {
            boxSprite = GetComponent<SpriteRenderer>();
        }
        boxSprite.color = boxColour;

        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfMoveable();

        if(canMove)
        {
            boxCollider.isTrigger = false;
        }
        else
        {
            boxCollider.isTrigger = true;
        }

        if (!collisionChck)
        {
            rb.linearVelocity = Vector2.zero;
            rb.rotation = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canMove && collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = transform.position - collision.transform.position;
            pushDirection.Normalize();


            rb.AddForce(pushDirection * pushforce, ForceMode2D.Force);
            Debug.Log("Pushing Box");
        }
        else if (!canMove)
        {
            Debug.Log("Box cannot move: collision ignored");
            return;
        }
    }

    void CheckIfMoveable()
    {
        if (revealableMaterial == null || !revealableMaterial.isRevealed)
        {
            Debug.Log("Box cannot move: not revealed");
            canMove = false;
            return;
        }

        if (player != null)
        {
            Debug.Log("Checking player light colour for box movement");
            PlayerLightController newLight = player.GetComponent<PlayerLightController>();

            if (newLight != null)
            {
                if (newLight.currentLightColour == requiredLightColour)
                {
                    Debug.Log("Box can move: correct light colour");
                    canMove = true;
                    boxSprite.color = boxColour; // normal colour
                }
                else
                {
                    Debug.Log("Box cannot move: incorrect light colour");
                    canMove = false;
                    boxSprite.color = Color.gray; // indicate cannot move
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionChck = false;
    }
}

