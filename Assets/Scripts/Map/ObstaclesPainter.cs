using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesPainter : MonoBehaviour
{
    private Transform _spawnedObjectsParent;
    [Serializable] public struct Obstacles
    {
        public string name;
        public float height;
        public GameObject gameObject;
    }
    [SerializeField] public List<Obstacles> terrainLevel = new List<Obstacles>();

    private void Start()
    {
        
    }

    public void Paint(float[,] terrainMap, float[,] obstacles1Map, float[,] obstacles2Map)
    {
        CreateObjectParentIfNeeded();
        for (int i = 0; i < terrainMap.GetLength(0); i++)
        {
            for (int j = 0; j < terrainMap.GetLength(1); j++)
            {
                if (obstacles1Map[i,j] > 0.5 && obstacles2Map[i,j] > 0.5)
                {
                    GameObject objectMap = null;
                    foreach (var level in terrainLevel)
                    {
                        // Если шум попадает в более низкий диапазон, то используем его
                        if (terrainMap[i,j] <= level.height)
                        {
                            objectMap = level.gameObject;
                            break;
                        }
                    }

                    if (objectMap != null)
                    {
                        
                        var spawnedObject = Instantiate(objectMap, new Vector3(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                        spawnedObject.transform.SetParent(_spawnedObjectsParent);
                    }
                }
            }
        }
    }

    private void CreateObjectParentIfNeeded()
    {
        if (_spawnedObjectsParent == null)
        {
            string name = "Obstacles";
            var parentObject = GameObject.Find(name);
            if (parentObject != null) _spawnedObjectsParent = parentObject.transform;
            else _spawnedObjectsParent = new GameObject(name).transform;
        }
    }
}
