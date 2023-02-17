using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public BulletController projectilePrefab;
    public Transform firePoint;

    public SpriteRenderer GunSprite;

    public EBullet bullet;

    public void Shoot()
    {
        BulletController projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileOdject._eBullet = bullet;
        // В ТАНККОНТРОЛЛЕР прокинуть  eBULLET 
        //var bullet = projectileOdject.GetComponent<Rigidbody2D>();
        //bullet.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
    }

    public void ChangeGun (Sprite newSpriteGun)
    {
        GunSprite.sprite = newSpriteGun;
    }
    
}
