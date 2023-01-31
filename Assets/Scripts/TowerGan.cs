using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGan : HpObject
{
    public GameObject bullet;
    private Vector2 lookDirection = new Vector2(0, 1);
    private Transform firePoint;
    public Transform firePointRight;
    public Transform firePointLeft;
    private Animator turret_Animator;

    public GameObject platform;
    private void Awake()
    {
        turret_Animator = GetComponent<Animator>();
    }


    public void Shot()
    {
        if (firePoint == firePointRight)
        {
            firePoint = firePointLeft;
        }
        else
        {
            firePoint = firePointRight;
        }
        GameObject bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2d = bulletObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce(firePoint.up * 20, ForceMode2D.Impulse);
        if (firePoint == firePointRight)
        {
            turret_Animator.SetTrigger("RightGun");
        }
        else
        {
            turret_Animator.SetTrigger("LeftGun");
        }

        //bulletObject.GetComponent<BulletController>().Launch(lookDirection, 300);
        //bulletObject.GetComponent<BulletController>().Debag();
    }
    public override void SetDamage(float damage)
    {
        _currentHpObject -= damage;
        if (_currentHpObject <= 0)
        {
            Destroy(platform);
        }
    }
}
