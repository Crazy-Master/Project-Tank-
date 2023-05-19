using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class TilePainter : MonoBehaviour
{
    public Tilemap tilemap;
    public float sid, n, zoom1;
    
    [Serializable]
    public struct TerrainLevel
    {
        public string name;
        public float height;
        public Tile tile;
        public Color color;
    }
    [SerializeField] public List<TerrainLevel> terrainLevel = new List<TerrainLevel>();

    [ContextMenu("Paint")]
    public void Paint(float[,] terrainMap)
    {
        for (int i = 0; i < terrainMap.GetLength(0); i++)
        {
            for (int j = 0; j < terrainMap.GetLength(1); j++)
            {
                Tile tileMap = null;
                foreach (var level in terrainLevel)
                {
                    // Если шум попадает в более низкий диапазон, то используем его
                    if (terrainMap[i,j] <= level.height)
                    {
                        tileMap = level.tile;
                        break;
                    }
                }
                tilemap.SetTile(new Vector3Int(i, j, 0), tileMap);
            }
        }
    }
}
