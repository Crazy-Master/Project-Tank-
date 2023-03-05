using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : MonoBehaviour, IShoot
{
    public EBullet bullet;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform _firePoint;
    
    private GameObject _Base;

    private ObjectPool _bulletPool;
    [SerializeField] private int _bulletpoolCount = 4;
    [SerializeField] private ParticleSystem muzzleFlashEffect;
    [SerializeField] private CanShoot _canShoot;

    //public float bulletDistance;
    private void Awake()
    {
        _bulletPool = GetComponent<ObjectPool>();
    }
    private void Start()
    {
        _bulletPool.Initialize(projectilePrefab, _bulletpoolCount);
    }
     

    public void Shoot()
    {
        if (_canShoot.CanShootNow())
        {
            Debug.Log("shoot");
            GameObject projectileOdject = _bulletPool.CreateObject(_firePoint);
            BulletController projectileBulletController = projectileOdject.gameObject.GetComponent<BulletController>();
            projectileBulletController._eBullet = bullet;
            projectileBulletController.creatorObject = _Base;
            muzzleFlashEffect.Play(); 
        }
    }
}
