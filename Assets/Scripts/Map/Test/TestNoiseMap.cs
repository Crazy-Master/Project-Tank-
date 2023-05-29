using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Random;

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

    [SerializeField] public GameObject prefab;

    private void Start()
    {
        GenerateMap();
    }

    [ContextMenu("Restart")]
    private void Restart()
    {
        for (int i = 0; i < 20; i++)
        {
            //seed = i;
            GenerateMap();
        }
        
    }
    
    public void GenerateMap()
    {
        // Генерируем карту
        float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale, octaves, persistence, lacunarity, offset);

        var n = 0;
        var m = 0;
        for (int i = 0; i < noiseMap.Length; i++)
        {
            if (noiseMap[i] > 0.65) 
                n++;
            else if (noiseMap[i] > 0.4) 
                m++;
            
        }
        Debug.Log(" seed-"+ seed + " деревья-"+ n + " кустарники-"+ m);
        if (n < 100 || m < 100) Debug.Log("пусто");
        
            // Передаём карту в рендерер
        TestNoiseMapRenderer mapRenderer = FindObjectOfType<TestNoiseMapRenderer>();
        mapRenderer.RenderMap(width, height, noiseMap, type);
    }

    [ContextMenu("RenderPrefab")]
    private void RenderPrefab()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                int nomber = 0;
                while (nomber == 0)
                {
                    scale = Range(1, 300);
                    octaves = Range(1, 11);
                    persistence = (float)((int)(Range(0.1f, 10f) * 10)) / 10;
                    lacunarity = (float)((int)(Range(0.1f, 10f) * 10)) / 10;

                    float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale, octaves,
                        persistence, lacunarity, offset);
                    for (int j = 0; j < noiseMap.Length; j++)
                    {
                        if (noiseMap[j] > 0.5)
                        {
                            nomber++;
                            break;
                        }
                    }
                    var gamePrefab = Instantiate(prefab, new Vector3(k * 2, i * 2, 0), Quaternion.identity);
                    gamePrefab.gameObject.GetComponent<textRender>().SetText(width, height, seed, scale, octaves,
                        persistence, lacunarity, offset);
                    gamePrefab.gameObject.GetComponent<TestNoiseMapRenderer>().RenderMap(width, height, noiseMap, type);
                }
            }
        }
        // for (int i = 0; i < 20; i++)
        // {
        //     float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale+i*5, octaves, persistence, lacunarity, offset);
        //     var gamePrefab =Instantiate(prefab, new Vector3(i * 2, 0, 0), Quaternion.identity);
        //     gamePrefab.gameObject.GetComponent<textRender>().SetText(width, height, seed, scale+i*5, octaves, persistence, lacunarity, offset);
        //     gamePrefab.gameObject.GetComponent<TestNoiseMapRenderer>().RenderMap(width, height, noiseMap, type);
        // }
        // for (int i = 0; i < 20; i++)
        // {
        //     float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale, octaves+i*1, persistence, lacunarity, offset);
        //     var gamePrefab =Instantiate(prefab, new Vector3(i * 2, -2, 0), Quaternion.identity);
        //     gamePrefab.gameObject.GetComponent<textRender>().SetText(width, height, seed, scale, octaves+i*1, persistence, lacunarity, offset);
        //     gamePrefab.gameObject.GetComponent<TestNoiseMapRenderer>().RenderMap(width, height, noiseMap, type);
        // }
        // for (int i = 0; i < 20; i++)
        // {
        //     float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale, octaves, persistence+i*0.5f, lacunarity, offset);
        //     var gamePrefab =Instantiate(prefab, new Vector3(i * 2, -4, 0), Quaternion.identity);
        //     gamePrefab.gameObject.GetComponent<textRender>().SetText(width, height, seed, scale, octaves, persistence+i*0.5f, lacunarity, offset);
        //     gamePrefab.gameObject.GetComponent<TestNoiseMapRenderer>().RenderMap(width, height, noiseMap, type);
        // }
        // for (int i = 0; i < 20; i++)
        // {
        //     float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale, octaves, persistence, lacunarity+i*0.5f, offset);
        //     var gamePrefab =Instantiate(prefab, new Vector3(i * 2, -6, 0), Quaternion.identity);
        //     gamePrefab.gameObject.GetComponent<textRender>().SetText(width, height, seed, scale, octaves, persistence, lacunarity+i*0.5f, offset);
        //     gamePrefab.gameObject.GetComponent<TestNoiseMapRenderer>().RenderMap(width, height, noiseMap, type);
        // }
        // for (int i = 0; i < 20; i++)
        // {
        //     float[] noiseMap = TestNoiseMapGenerator.GenerateNoiseMap(width, height, seed, scale+i*5, octaves+i*1, persistence+i*0.5f, lacunarity+i*0.5f, offset);
        //     var gamePrefab =Instantiate(prefab, new Vector3(i * 2, -8, 0), Quaternion.identity);
        //     gamePrefab.gameObject.GetComponent<textRender>().SetText(width, height, seed, scale+i*5, octaves+i*1, persistence+i*0.5f, lacunarity+i*0.5f, offset);
        //     gamePrefab.gameObject.GetComponent<TestNoiseMapRenderer>().RenderMap(width, height, noiseMap, type);
        // }
    }
}
