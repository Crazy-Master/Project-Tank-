using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGunNPS : MonoBehaviour
{
    public BulletController projectilePrefab;
    public Transform firePoint;
    public EBullet bullet;

    public void Shoot()
    {
        BulletController projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileOdject._eBullet = bullet;
    }
}
