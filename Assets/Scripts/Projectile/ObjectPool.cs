using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _poolSizeStarting = 100;
    //[SerializeField] private int _poolSizeMax = 100;
    
    private static Queue<GameObject> _objectPool;
    private Transform _spawnedObjectsParent;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        for (int i = 0; i < _poolSizeStarting; i++)
        {
            CreateObjectInStart();
        }
    }

    
    
    private void Awake()
    {
        _objectPool = new Queue<GameObject>();
    }
    
    
    
    public void Initialize(GameObject objectToPool)
    {
        this._objectToPool = objectToPool;
    }

    private void CreateObjectInStart()
    {
        CreateObjectParentIfNeeded();
        
        GameObject spawnedObject = null;
        var transform1 = instance.transform;
        spawnedObject = Instantiate(_objectToPool, transform1.position, transform1.rotation);
        spawnedObject.name = _objectToPool.name + "_" + _objectPool.Count; //transform.root.name + "_" + 
        spawnedObject.transform.SetParent(_spawnedObjectsParent);
        spawnedObject.SetActive(false);
        
        _objectPool.Enqueue(spawnedObject);
    }
    
    public GameObject CreateObject(Transform firePoint)
    {
        //GameObject spawnedObject = null;
        // if (_objectPool.Dequeue().activeSelf && _objectPool.Count < _poolSizeMax)
        // {
        //     var transform1 = instance.transform;
        //     spawnedObject = Instantiate(_objectToPool, firePoint.position, firePoint.rotation);
        //     spawnedObject.name = _objectToPool.name + "_" + _objectPool.Count; //transform.root.name + "_" + 
        //     spawnedObject.transform.SetParent(_spawnedObjectsParent);
        // }
        // else
        // {
        var spawnedObject = _objectPool.Dequeue();
        spawnedObject.transform.position = firePoint.position;
        spawnedObject.transform.rotation = firePoint.rotation; 
        spawnedObject.gameObject.SetActive(true);
        spawnedObject.GetComponent<BulletController>().AddForceBullet();

        _objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }
    
    private void CreateObjectParentIfNeeded()
    {
        if (_spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + _objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null) _spawnedObjectsParent = parentObject.transform;
            else _spawnedObjectsParent = new GameObject(name).transform;
        }
    }
}
