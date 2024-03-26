using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("collide");// Handle collision with player (e.g., call a method or set a flag)

            // Disable the "is Trigger" property to make it a solid collision
            Collider2D collider = GetComponent<Collider2D>();
            collider.isTrigger = false;
        }
    }
}
