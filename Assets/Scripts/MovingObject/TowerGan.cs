using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGan : HpObject
{
    private Transform firePoint;
    public Transform firePointRight;
    public Transform firePointLeft;
    private Animator turret_Animator;
    public ParticleSystem sleevEffectL;
    public ParticleSystem sleevEffectR;
    public ParticleSystem muzzleFlashEffectL;
    public ParticleSystem muzzleFlashEffectR;

    public GameObject platform;
    public GameObject bullet;
    public GameObject remnants;
    
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
        Debug.Log("123");
        GameObject bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bulletObject.GetComponent<BulletController>().AddForceBullet();
        if (firePoint == firePointRight)
        {
            turret_Animator.SetTrigger("RightGun");
            muzzleFlashEffectR.Play();
            sleevEffectR.Play();
        }
        else
        {
            turret_Animator.SetTrigger("LeftGun");
            muzzleFlashEffectL.Play();
            sleevEffectL.Play();
        }

        //bulletObject.GetComponent<BulletController>().Launch(lookDirection, 300);
        //bulletObject.GetComponent<BulletController>().Debag();
    }
    public override void SetDamage(float damage)
    {
        _currentHpObject -= damage;
        if (_currentHpObject <= 0)
        {
            GameObject remnantsObject = Instantiate(remnants, platform.transform.position, platform.transform.rotation);
            remnantsObject.GetComponent<RemnantsExplosion>().DestroyTurret(platform);
        }
    
    }
}
