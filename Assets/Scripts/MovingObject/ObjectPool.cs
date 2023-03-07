using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    protected GameObject _objectToPool;
    protected int _poolSize = 10;
    
    protected Queue<GameObject> _objectPool;
    private Transform spawnedObjectsParent;

    private void Awake()
    {
        _objectPool = new Queue<GameObject>();
    }

    public void Initialize(GameObject objectToPool, int poolSize = 10)
    {
        this._objectToPool = objectToPool;
        this._poolSize = poolSize;
    }

    public GameObject CreateObject(Transform firePoint)
    {
        CreateObjectParentIfNeeded();
        
        GameObject spawnedObject = null;
        if (_objectPool.Count < _poolSize)
        {
            spawnedObject = Instantiate(_objectToPool, firePoint.position, firePoint.rotation);
            spawnedObject.name = transform.root.name + "_" + _objectToPool.name + "_" + _objectPool.Count;
            spawnedObject.transform.SetParent(spawnedObjectsParent);
            spawnedObject.GetComponent<BulletController>().AddForceBullet();
            spawnedObject.AddComponent<DestroyIfDisabled>();
        }
        else
        {
            spawnedObject = _objectPool.Dequeue();
            spawnedObject.transform.position = firePoint.position;
            spawnedObject.transform.rotation = firePoint.rotation;
            spawnedObject.gameObject.SetActive(true);
            spawnedObject.GetComponent<BulletController>().AddForceBullet();
        }
        
        _objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + _objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null) spawnedObjectsParent = parentObject.transform;
            else spawnedObjectsParent = new GameObject(name).transform;
        }
    }

    private void OnDestroy()
    {
        foreach (var item in _objectPool)
        {
            if (item != null)
            {
                if (item.activeSelf == false)
                    Destroy(item);
                else
                    item.GetComponent<DestroyIfDisabled>().SelfDestructionEnabled = true;
            }
        }
    }
}
