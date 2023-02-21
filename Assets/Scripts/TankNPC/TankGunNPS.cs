using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class TankGunNPS : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public EBullet bullet;
    
    private TankBaseNPS _tankBaseNPS;
    private bool _isRecharge;
    [SerializeField] private float _timerRecharge = 0.5f;

    private ObjectPool _bulletPool;
    [SerializeField] private int _bulletpoolCount = 2;

    private void Awake()
    {
        _tankBaseNPS = GetComponentInParent<TankBaseNPS>();
        _bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        _bulletPool.Initialize(projectilePrefab, _bulletpoolCount);
    }

    public void Shoot()
    {
        if (!_isRecharge)
        {
            //BulletController projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            GameObject projectileOdject = _bulletPool.CreateObject(firePoint);
            BulletController projectileBulletController = projectileOdject.gameObject.GetComponent<BulletController>();
            projectileBulletController._eBullet = bullet;
            projectileBulletController.creatorObject = _tankBaseNPS;
            _isRecharge = true;
            Invoke(nameof(Recharge), _timerRecharge);
        }
    }

    
    private void Recharge()
    {
        _isRecharge = false;
    }
}
