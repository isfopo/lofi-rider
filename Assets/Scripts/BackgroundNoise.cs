using UnityEngine;

public class BackgroundNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public Vector2 redRange;
    public Vector2 greenRange;
    public Vector2 blueRange;

    private void Start()
    {
        
    }
    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for ( int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                texture.SetPixel(x, y, CalculateColor());
            }
        }
        texture.Apply();
        return texture;
    }

    Color CalculateColor()
    {
        float sample = Random.value;
        return new Color(
            Mathf.SmoothStep(redRange.x, redRange.y, sample),
            Mathf.SmoothStep(greenRange.x, greenRange.y, sample),
            Mathf.SmoothStep(blueRange.x, blueRange.y, sample)
        );
    }
}