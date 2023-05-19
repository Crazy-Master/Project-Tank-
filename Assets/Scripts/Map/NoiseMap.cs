using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

// public enum MapType
// {
//     Noise,
//     Color
// }

public class NoiseMap : MonoBehaviour
{
    [Serializable]
    public struct Generate
    {
        [SerializeField] public string name;
        // Исходные данные для нашего генератора шума
        [SerializeField] public int width;
        [SerializeField] public int height;
        [SerializeField] public float scale;

        [SerializeField] public int octaves;
        [SerializeField] public float persistence;
        [SerializeField] public float lacunarity;
        [SerializeField] public Vector2 offset;
    }
    [SerializeField] private List<Generate> generate = new List<Generate>();
    
    [SerializeField] public int seed;

    [SerializeField] private TilePainter tilePainter;
    [SerializeField] private ObstaclesPainter obstaclesPainter;
    
    private float[,] terrainMap;

    private void Start()
    {
        Restart();
    }

    [ContextMenu("Restart")]
    private void Restart()
    {
        seed = Random.Range(0, 999999);
        GenerateTerrain();
        GenerateObstacles();
    }
    
    public void GenerateTerrain()
    {
        var gT = generate[0];
        // Генерируем карту
        terrainMap = NoiseMapGenerator.GenerateNoiseMap(gT.width, gT.height, seed, gT.scale, gT.octaves, gT.persistence, gT.lacunarity, gT.offset);
        tilePainter.Paint(terrainMap);
    }
    
    public void GenerateObstacles()
    {
        var gT = generate[1];
        var gY = generate[2];
        // Генерируем карту
        var obstacles1Map = NoiseMapGenerator.GenerateNoiseMap(gT.width, gT.height, seed, gT.scale, gT.octaves, gT.persistence, gT.lacunarity, gT.offset);
        var obstacles2Map = NoiseMapGenerator.GenerateNoiseMap(gY.width, gY.height, seed, gY.scale, gY.octaves, gY.persistence, gY.lacunarity, gY.offset);
        obstaclesPainter.Paint(terrainMap, obstacles1Map, obstacles2Map);
    }
}