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
        //seed = Random.Range(0, 999999);
        GenerateTerrain();
        GenerateObstacles();
    }
    
    public void GenerateTerrain()
    {
        var gT = generate[0];
        var gy = generate[1];
        // Генерируем карту
        terrainMap = NoiseMapGenerator.GenerateNoiseMap(gT.width, gT.height, seed, gT.scale, gT.octaves, gT.persistence, gT.lacunarity, gT.offset);
        var terrainType = NoiseMapGenerator.GenerateNoiseMap(gy.width, gy.height, seed, gy.scale, gy.octaves, gy.persistence, gy.lacunarity, gy.offset);
        tilePainter.PaintTerrain(terrainMap, terrainType);
    }
    
    public void GenerateObstacles()
    {
        var gB = generate[2];
        var gD = generate[3];
        var gE = generate[4];
        var gC = generate[5];
        var gR = generate[6];
        
        var obstaclesB = NoiseMapGenerator.GenerateNoiseMap(gB.width, gB.height, seed, gB.scale, gB.octaves, gB.persistence, gB.lacunarity, gB.offset);
        var obstaclesD = NoiseMapGenerator.GenerateNoiseMap(gD.width, gD.height, seed, gD.scale, gD.octaves, gD.persistence, gD.lacunarity, gD.offset);
        var obstaclesE = NoiseMapGenerator.GenerateNoiseMap(gE.width, gE.height, seed, gE.scale, gE.octaves, gE.persistence, gE.lacunarity, gE.offset);
        var obstaclesC = NoiseMapGenerator.GenerateNoiseMap(gC.width, gC.height, seed, gC.scale, gC.octaves, gC.persistence, gC.lacunarity, gC.offset);
        var obstaclesR = NoiseMapGenerator.GenerateNoiseMap(gR.width, gR.height, seed, gR.scale, gR.octaves, gR.persistence, gR.lacunarity, gR.offset);
        
        obstaclesPainter.PaintObstacles(terrainMap, obstaclesB, obstaclesD,obstaclesE,obstaclesC,obstaclesR);
    }
}