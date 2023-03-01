using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public BulletController projectilePrefab;
    public Transform firePoint;

    public SpriteRenderer GunSprite;

    [SerializeField] private float reloadGun;
    private float _reloadTime;
    private bool readyShoot=true;

    public EBullet bullet;
    public void Start()
    {
        _reloadTime = reloadGun;
    }

    public void FixedUpdate()
    {
        if (!readyShoot)
        {
            _reloadTime -= Time.deltaTime;
            if (_reloadTime < 0)
            { readyShoot = true; }
        }
        Debug.Log(readyShoot);
        Debug.Log(_reloadTime);
    }
    public void Shoot()
    {
        if (readyShoot)
        {
            BulletController projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectileOdject._eBullet = bullet;            
            readyShoot = false;
            _reloadTime = reloadGun;
            // Â ÒÀÍÊÊÎÍÒÐÎËËÅÐ ïðîêèíóòü  eBULLET 
            //var bullet = projectileOdject.GetComponent<Rigidbody2D>();
            //bullet.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
        }
    }

    public void ChangeGun (Sprite newSpriteGun)
    {
        GunSprite.sprite = newSpriteGun;
    }
    
}
