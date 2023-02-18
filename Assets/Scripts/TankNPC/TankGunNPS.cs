using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGunNPS : MonoBehaviour
{
    public BulletController projectilePrefab;
    public Transform firePoint;
    public EBullet bullet;
    
    private TankBaseNPS _tankBaseNPS;
    private float _rechargeTimer;
    private bool _isRecharge;
    [SerializeField] private float _timerRecharge = 0.7f;

    private void Awake()
    {
        _tankBaseNPS = GetComponentInParent<TankBaseNPS>();
    }

    private void FixedUpdate()
    {
        if (_isRecharge) Recharge();
    }

    public void Shoot()
    {
        if (_isRecharge == false)
        {
            BulletController projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectileOdject._eBullet = bullet;
            projectileOdject.creatorObject = _tankBaseNPS;
        }
        _isRecharge = true;
    }

    private void Recharge()
    {
        _rechargeTimer -= Time.deltaTime;
        if (_rechargeTimer < 0)
        {
            _isRecharge = false;
            _rechargeTimer = _timerRecharge;
        }
    }
}
