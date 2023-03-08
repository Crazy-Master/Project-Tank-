using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance = null;
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _poolSizeMax = 50;
    
    private Queue<GameObject> _objectPool;
    private Transform _spawnedObjectsParent;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            for (int i = 0; i < _poolSizeMax; i++)
            {
                CreateObjectInStart();
            }
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    
    
    private void Awake()
    {
        _objectPool = new Queue<GameObject>();
    }
    
    
    
    public void Initialize(GameObject objectToPool)
    {
        this._objectToPool = objectToPool;
    }

    public void CreateObjectInStart()
    {
        CreateObjectParentIfNeeded();
        
        GameObject spawnedObject = null;
        var transform1 = instance.transform;
        spawnedObject = Instantiate(_objectToPool, transform1.position, transform1.rotation);
        spawnedObject.name = transform.root.name + "_" + _objectToPool.name + "_" + _objectPool.Count;
        spawnedObject.transform.SetParent(_spawnedObjectsParent);
        spawnedObject.GetComponent<BulletController>().AddForceBullet();
        spawnedObject.AddComponent<DestroyIfDisabled>();
        spawnedObject.SetActive(false);
        
        _objectPool.Enqueue(spawnedObject);
    }
    
    public GameObject CreateObject(Transform firePoint)
    {
        //CreateObjectParentIfNeeded();
        
        GameObject spawnedObject = null;
        // if (_objectPool.Dequeue().activeSelf == false) // || _objectPool.Count < _poolSizeMax
        // {
        //     spawnedObject = Instantiate(_objectToPool, firePoint.position, firePoint.rotation);
        //     spawnedObject.name = transform.root.name + "_" + _objectToPool.name + "_" + _objectPool.Count;
        //     spawnedObject.transform.SetParent(_spawnedObjectsParent);
        //     spawnedObject.GetComponent<BulletController>().AddForceBullet();
        //     spawnedObject.AddComponent<DestroyIfDisabled>();
        // }
        // else
        spawnedObject = _objectPool.Dequeue();
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
    
    // private void OnDestroy()
    // {
    //     foreach (var item in _objectPool)
    //     {
    //         if (item != null)
    //         {
    //             if (item.activeSelf == false)
    //                 Destroy(item);
    //             else
    //                 item.GetComponent<DestroyIfDisabled>().SelfDestructionEnabled = true;
    //         }
    //     }
    // }
}
