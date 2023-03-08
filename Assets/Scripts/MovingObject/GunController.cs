using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour, IShoot
{
    private EBullet bullet;
    //[SerializeField] private GameObject projectilePrefab; //что делать при разных видах снарядов (лазер)
    [SerializeField] private Transform _firePoint;
    
    private GameObject _Base;

    private ObjectPool _bulletPool;
    private ICanShoot[] _canShoot;
    private bool _canShootNow;
    
    [SerializeField] private ParticleSystem muzzleFlashEffect; // возможно, стоит выделить анимацию в отдельный класс
    //[SerializeField] private Animator turret_Animator;         // возможно, стоит выделить анимацию в отдельный класс
    //[SerializeField] private ParticleSystem sleevEffect;       // возможно, стоит выделить анимацию в отдельный класс

    //public float bulletDistance; 
    private void Awake()
    {
        _canShoot = GetComponents<ICanShoot>();
    }
    
    public void Shoot()
    {
        if (_bulletPool == null)
        {
            _bulletPool = ObjectPool.instance;
        }
        
        if (CanShoot())
        {
            GameObject projectileOdject = _bulletPool.CreateObject(_firePoint);
            BulletController projectileBulletController = projectileOdject.gameObject.GetComponent<BulletController>();
            projectileBulletController._eBullet = bullet;
            projectileBulletController.creatorObject = _Base;
            AnimatorGun();
        }
    }

    private void AnimatorGun()
    {
        muzzleFlashEffect.Play();
    }
    
    public bool CanShoot()
    {
        _canShootNow = true;
        foreach (var canShoot in _canShoot)
        {
            var can = canShoot.CanShootNow();
            if (can == false || _canShootNow == false)
            {
                _canShootNow = false;
            }
        }
        return _canShootNow;
    }
}
