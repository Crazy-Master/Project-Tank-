using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesPainter : MonoBehaviour
{
    private Transform _spawnedObjectsParent;
    [Serializable] public struct TypeTrees
    {
        public string name;
        public float height;
        public GameObject gameObject;
    }
    [SerializeField] public List<TypeTrees> typeTrees = new List<TypeTrees>();
    
    
    [Serializable] public struct TypeBushes
    {
        public string name;
        public float height;
        public GameObject gameObject;
    }
    [SerializeField] public List<TypeBushes> typeBushes = new List<TypeBushes>();

    
    [Serializable] public struct TypeRoots
    {
        public string name;
        public float height;
        public GameObject gameObject;
    }
    [SerializeField] public List<TypeRoots> typeRoots = new List<TypeRoots>();
    
    
    [Serializable] public struct TypeCacti
    {
        public string name;
        public float height;
        public GameObject gameObject;
    }
    [SerializeField] public List<TypeCacti> typeCacti = new List<TypeCacti>();
    
    
    [Serializable] public struct TypeStones
    {
        public string name;
        public float height;
        public GameObject gameObject;
    }
    [SerializeField] public List<TypeStones> typeStones = new List<TypeStones>();

    private void Start()
    {
        
    }

    public void PaintObstacles(float[,] terrainMap, float[,] obstaclesB, float[,] obstaclesD, float[,] obstaclesE, float[,] obstaclesC, float[,] obstaclesR)
    {
        CreateObjectParentIfNeeded();
        for (int i = 0; i < terrainMap.GetLength(0); i++)
        {
            for (int j = 0; j < terrainMap.GetLength(1); j++)
            {
                GameObject objectMap = null;  
                if (terrainMap[i, j] <= 0.15)
                {
                    if (obstaclesC[i, j] > 0.95)
                    {
                        #region CreateRoots

                        foreach (var level in typeRoots) 
                            if (obstaclesR[i, j] <= level.height)
                            {
                                objectMap = level.gameObject;
                                break;
                            }
        
                        if (objectMap != null)
                        {
                            var spawnedObject = Instantiate(objectMap, new Vector3(i, j),Quaternion.identity);//(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                            spawnedObject.transform.SetParent(_spawnedObjectsParent);
                        }

                        #endregion
                    }
                        
                }else if (terrainMap[i, j] <= 0.2)
                {
                    if (obstaclesC[i, j] <= 0.1)
                    {
                        #region CreateCacti

                        foreach (var level in typeCacti) 
                            if (obstaclesR[i, j] <= level.height)
                            {
                                objectMap = level.gameObject;
                                break;
                            }
        
                        if (objectMap != null)
                        {
                            var spawnedObject = Instantiate(objectMap, new Vector3(i, j),Quaternion.identity);//(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                            spawnedObject.transform.SetParent(_spawnedObjectsParent);
                        }

                        #endregion
                    }
                }else if (terrainMap[i, j] <= 0.65)
                {
                    if (obstaclesB[i, j] >= 0.5)
                    {if (obstaclesD[i, j] >= 0.6)
                        {
                            #region CreateTrees

                            foreach (var level in typeTrees) 
                                if (obstaclesR[i, j] <= level.height)
                                {
                                    objectMap = level.gameObject;
                                    break;
                                }
        
                            if (objectMap != null)
                            {
                                var spawnedObject = Instantiate(objectMap, new Vector3(i, j),Quaternion.identity);//(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                                spawnedObject.transform.SetParent(_spawnedObjectsParent);
                            }

                            #endregion
                        }
                        else if (obstaclesD[i, j] >= 0.5)
                        {
                            #region CreateBushes

                            foreach (var level in typeBushes) 
                                if (obstaclesR[i, j] <= level.height)
                                {
                                    objectMap = level.gameObject;
                                    break;
                                }
        
                            if (objectMap != null)
                            {
                                var spawnedObject = Instantiate(objectMap, new Vector3(i, j),Quaternion.identity);//(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                                spawnedObject.transform.SetParent(_spawnedObjectsParent);
                            }

                            #endregion
                        }
                    }
                    else if (obstaclesB[i, j] >= 0.4)
                            if (obstaclesD[i, j] >=0.7)
                            {
                                #region CreateBushes

                                foreach (var level in typeBushes) 
                                    if (obstaclesR[i, j] <= level.height)
                                    {
                                        objectMap = level.gameObject;
                                        break;
                                    }
        
                                if (objectMap != null)
                                {
                                    var spawnedObject = Instantiate(objectMap, new Vector3(i, j),Quaternion.identity);//(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                                    spawnedObject.transform.SetParent(_spawnedObjectsParent);
                                }

                                #endregion
                            }
                }else if (terrainMap[i, j] >= 0.75) 
                    if (obstaclesR[i, j] >=0.7) 
                    {
                        #region CreateStones

                        foreach (var level in typeStones) 
                            if (obstaclesR[i, j] <= level.height)
                            {
                                objectMap = level.gameObject;
                                break;
                            }
        
                        if (objectMap != null)
                        {
                            var spawnedObject = Instantiate(objectMap, new Vector3(i, j),Quaternion.identity);//(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                            spawnedObject.transform.SetParent(_spawnedObjectsParent);
                        }

                        #endregion
                    }
                    
                    
                //     GameObject objectMap = null;
                //     foreach (var level in obstaclesLevel)
                //     {
                //         // Если шум попадает в более низкий диапазон, то используем его
                //         if (terrainMap[i,j] <= level.height)
                //         {
                //             objectMap = level.gameObject;
                //             break;
                //         }
                //     }
                //
                //     if (objectMap != null)
                //     {
                //         
                //         var spawnedObject = Instantiate(objectMap, new Vector3(i + Random.Range(0,1), j + Random.Range(0,1)), Quaternion.Euler(0,0,Random.Range(0, 360)));
                //         spawnedObject.transform.SetParent(_spawnedObjectsParent);
                //     }
                // }
                // else // скалы
                // {
                //     if (obstaclesE[i, j] > 0.7 && obstaclesE[i, j] < 0.8)
                //         foreach (var level in obstaclesLevel) 
                //             if (terrainMap[i, j] <= level.height)
                //             {
                //             }
                //     
                // }
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
