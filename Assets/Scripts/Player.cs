using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public float jumpForce = 100f; // Adjust the jump force as needed
    public float gravity = -2.3f;
    public float tilt = 5f;

    private Vector3 direction;
    private bool isGravityEnabled = true;
    private bool canMove = true;

    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
        isGravityEnabled = true;
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            if (isGravityEnabled)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    Jump(); // Call the Jump method
                }
                else
                {
                    direction = Vector3.up * gravity;
                }
            }
            else
            {
                float gravityScale = -10f; // Adjust this value as needed
                rb.gravityScale = gravityScale;            }
        }
        else 
        {
            Explode();
            SceneManager.LoadScene(2);
        }

        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void Jump()
    {
        // Apply a jump force when called
        direction = Vector3.up * jumpForce;
    }

    public void Explode()
    {
        // Apply a jump force when called
        direction =  Vector3.left * (5f);
        
    }
    
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Jump(); // Trigger a jump when colliding with an obstacle
            DisableGravity();
            DisableMovement();
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            Debug.Log("The Score Work!");

        }
    }

    private void DisableGravity()
    {
        isGravityEnabled = false;
    }

    private void DisableMovement()
    {
        canMove = false;
    }
    private void ApplyRandomForce()
    {
        // Generate a random direction for the force
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Apply a random force with a magnitude in a range
        float minForceMagnitude = 100f;
        float maxForceMagnitude = 200f;
        float randomForceMagnitude = Random.Range(minForceMagnitude, maxForceMagnitude);

        // Apply the random force to the rigidbody
        rb.AddForce(randomDirection * randomForceMagnitude);
    }
}