using UnityEngine;

public enum MapType
{
    Noise,
    Color
}

public class TestNoiseMap : MonoBehaviour
{
    // Исходные данные для нашего генератора шума
    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] public float scale;

    [SerializeField] public int octaves;
    [SerializeField] public float persistence;
    [SerializeField] public float lacunarity;

    [SerializeField] public int seed;
    [SerializeField] public Vector2 offset;

    [SerializeField] public MapType type = MapType.Noise;

    private void Start()
    {
        GenerateMap();
    }

    [ContextMenu("Restart")]
    private void Restart()
    {
        GenerateMap();
    }
    
    public void GenerateMap()
    {
        // Генерируем карту
        float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale, octaves, persistence, lacunarity, offset);

        var n = 0;
        for (int i = 0; i < noiseMap.Length; i++)
        {
            if (noiseMap[i] > 0.5)
            {
                n++;
            }
        }
        Debug.Log(n);
        
        
            // Передаём карту в рендерер
        TestNoiseMapRenderer mapRenderer = FindObjectOfType<TestNoiseMapRenderer>();
        mapRenderer.RenderMap(width, height, noiseMap, type);
    }
}
