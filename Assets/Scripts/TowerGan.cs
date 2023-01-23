using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGan : MonoBehaviour
{
    public GameObject bullet;
    private Vector2 lookDirection = new Vector2(0, 1);
    private Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    
    
    

    public void Strike()
    {
        if (firePoint == firePoint1)
        {
            firePoint = firePoint2;
        }
        else
        {
            firePoint = firePoint1;
        }
        GameObject bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2d = bulletObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce(firePoint.up * 20, ForceMode2D.Impulse);

        //bulletObject.GetComponent<BulletController>().Launch(lookDirection, 300);
        //bulletObject.GetComponent<BulletController>().Debag();
    }
}
