using UnityEngine;

public class ShowFlag : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update is working!"); // Uncomment if you want to check if Update is called.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collision detected!");

            // Change the object's position in the y-axis by +1.38 units
            Vector3 newPosition = transform.position;
            newPosition.y += 1.38f;
            transform.position = newPosition;

            direction = Vector3.up * 5f;

            Debug.Log("Object's position updated!");
        }
    }
}