using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float smoothTime = 0.1f;

    [Header("Light Settings")]
    public float baseLightRadius = 1f;
    public float maxLightRadius = 3f;
    public float lightRadiusIncreaseSpeed = 0.5f;

    // Boundaries for player movement
    private float minX, maxX, minY, maxY;

    private CircleCollider2D colliderSize;
    private Rigidbody2D rb;
    private Light2D playerLight;
    private Vector2 currentVelocity;

    public Vector2 moveDirection;

    void Start()
    {
        // attatch components and set initial light radius
        rb = GetComponent<Rigidbody2D>();
        playerLight = GetComponent<Light2D>();
        colliderSize = GetComponent<CircleCollider2D>();
        playerLight.pointLightOuterRadius = baseLightRadius;

        // Define movement boundaries based on camera view
        var spirteSize = GetComponent<SpriteRenderer>().bounds.size;
        Camera mainCamera = Camera.main;
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minY = bottomLeft.y + spirteSize.y / 2;
        maxY = topRight.y - spirteSize.y / 2;

        minX = bottomLeft.x + spirteSize.x / 2;
        maxX = topRight.x - spirteSize.x / 2;
    }

    void Update()
    {
        // updatte movement and light radius based on input each frame
        Movement();
        LightInput();

        colliderSize.radius = playerLight.pointLightOuterRadius - 0.5f;

    }

    void Movement()
    {
        // Get input axes
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;

        // Calculate target velocity and smoothly transition to it
        Vector2 targetVelocity = new Vector2(horizontal, vertical) * moveSpeed;
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Clamp player position within defined boundaries
        var xValidPos = Mathf.Clamp(transform.position.x, minX, maxX);
        var yValidPos = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(xValidPos, yValidPos);
    }

    void LightInput()
    {
        // light radius increases when space is held down and decreases when released
        if (Input.GetKey(KeyCode.Space))
        {
            playerLight.pointLightOuterRadius = Mathf.Lerp(playerLight.pointLightOuterRadius, maxLightRadius, Time.deltaTime * lightRadiusIncreaseSpeed);
        }
        else
        {
            playerLight.pointLightOuterRadius = Mathf.Lerp(playerLight.pointLightOuterRadius, baseLightRadius, Time.deltaTime * lightRadiusIncreaseSpeed);
        }
    }

}
