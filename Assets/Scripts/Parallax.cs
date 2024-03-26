using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float horizontalScrollSpeed = 0.05f; // Horizontal scroll speed
    public float verticalScrollSpeed = 0f;   // Vertical scroll speed

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // Calculate the new offset for both horizontal and vertical scrolling
        Vector2 offset = new Vector2(horizontalScrollSpeed * Time.deltaTime, verticalScrollSpeed * Time.deltaTime);
        
        // Update the mainTextureOffset
        meshRenderer.material.mainTextureOffset += offset;
    }
}