using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile water, grass, sand, dirt, mountains;
    public float sid, n, m, h, zoom1, zoom2;

    [ContextMenu("Paint")]
    void Paint()
    {
        sid = Random.Range(0, 9999999);
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                h = Mathf.PerlinNoise((i + sid) / zoom1, (j + sid) / zoom1);
                m = Mathf.PerlinNoise((i + sid) / zoom2, (j + sid) / zoom2);
                n = h * m;
                
                if (n < 0.2)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), water);
                }
                else if (n > 0.2 && n <0.4)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), grass);
                }
                else if (n > 0.4 && n <0.6)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), sand);
                }
                else if (n > 0.6 && n <0.8)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), dirt);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), mountains);
                }
            }
        }
    }
}
