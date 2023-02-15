using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public BulletController projectilePrefab;
    public Transform firePoint;
    public void shoot()
    {
        BulletController projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        // В ТАНККОНТРОЛЛЕР прокинуть  eBULLET 
        //var bullet = projectileOdject.GetComponent<Rigidbody2D>();
        //bullet.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
    }
}
