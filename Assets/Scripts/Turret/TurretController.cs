using System.Collections.Generic;
using UnityEngine;


public class TurretController : MonoBehaviour
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

                
                if (Quaternion.Angle(turretParent.rotation,Quaternion.Euler(0, 0, desiredAngle)) < 15)
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
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<HpObject>() == null || other.gameObject == towerTurret)
        {
            return;
        }
        
        _enemies.Add(other.gameObject.GetComponent<HpObject>());
        _player = ChoosingEnemy();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemies.Remove(other.gameObject.GetComponent<HpObject>());
        if (_enemies.Count > 0 && _player == other.gameObject.transform || other.gameObject == towerTurret)
        {
            _player = ChoosingEnemy();
        }
    }

    Transform ChoosingEnemy()
    {
        float minHp = 999;
        HpObject tankCont = null;
        foreach (var variable in _enemies)
        {
            var hp = variable.HpObjectManager;
            if (minHp > hp)
            {
                tankCont = variable;
                minHp = hp;
            }
        }

        if (tankCont is not null) return tankCont.transform;
        return null;
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
