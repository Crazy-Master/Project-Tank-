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
    [SerializeField] private ICanShoot _canShoot;
    
    [SerializeField] private ParticleSystem muzzleFlashEffect; // возможно, стоит выделить анимацию в отдельный класс
    //[SerializeField] private Animator turret_Animator;         // возможно, стоит выделить анимацию в отдельный класс
    //[SerializeField] private ParticleSystem sleevEffect;       // возможно, стоит выделить анимацию в отдельный класс

    //public float bulletDistance; 
    private void Awake()
    {
        _canShoot = GetComponent<ICanShoot>();
    }
    
    public void Shoot()
    {
        if (_bulletPool == null)
        {
            _bulletPool = ObjectPool.instance;
        }
        
        if (_canShoot.CanShootNow())
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
}
