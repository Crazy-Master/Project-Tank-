using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : MonoBehaviour
{
    public Rigidbody2D rd2d;
    private Vector2 _movementVector;
    public float turretRotationSpeed;
    public Transform turretParent;
    private Transform _player;

    public float rechargeTimer;
    public float timerRecharge = 0.7f;
    
    private List<HpObject> _enemies = new List<HpObject>();

    public TowerGan towerGan;
    public GameObject towerTurret;

   
    

    private bool _isRecharge;
    //public float bulletDistance; 

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }
    

    public void FixedUpdate()
    {
        if (_enemies.Count > 0)
        {
            if (_player != null)
            {
                var turretDirection = _player.position - turretParent.position;
                
                var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

                var rotatrionStep = turretRotationSpeed * Time.fixedDeltaTime;
                turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation,
                    Quaternion.Euler(0, 0, desiredAngle), rotatrionStep);

                
                if (towerGan.HpObjectManager > 0 && Quaternion.Angle(turretParent.rotation,Quaternion.Euler(0, 0, desiredAngle)) < 15)
                {
                    TowerGun();
                }
                
            }
        }

        if (!_isRecharge) return;
        rechargeTimer -= Time.deltaTime;
        if (rechargeTimer < 0)
                
            _isRecharge = false;
        
    }
    private void TowerGun()
    {
        if (_isRecharge == false)
        {
            towerGan.Shot();
            _isRecharge = true;
            rechargeTimer = timerRecharge;
        }
    }
}
