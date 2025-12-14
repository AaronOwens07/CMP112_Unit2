using UnityEngine;

public class MoveableBox : MonoBehaviour
{
    public RevealableMaterial revealableMaterial;
    public PlayerLightController playerLightController;
   public GameObject player;

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public int minX, maxX, minY, maxY;
    public float pushforce = 5f;
    public bool canMove;
    public bool collisionChck;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnBox();

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player != null)
        {
            playerLightController = player.GetComponent<PlayerLightController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkReveal();
      
        if(!collisionChck)
        {
            rb.linearVelocity = Vector2.zero;
            rb.rotation = 0f;
        }
    }

    void checkReveal()
    {
        
        if (revealableMaterial.isRevealed)
        {
            canMove = true;
              boxCollider.isTrigger = false;
        }
        else         {
            canMove = false;
            boxCollider.isTrigger = true;
        }
    }

    void spawnBox()
    {
        //Random element equivilant to Mathf.Random to get a random position within set boundaries

        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY , maxY));
        transform.position = spawnPosition;

        Debug.Log("Box Spawned at: " + spawnPosition + "using Random.Range");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collisionChck = true;
        if (!canMove)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = transform.position - collision.transform.position;
            pushDirection.Normalize();

     
            rb.AddForce(pushDirection * pushforce, ForceMode2D.Force);
            Debug.Log("Pushing Box");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionChck = false;
    }
}

