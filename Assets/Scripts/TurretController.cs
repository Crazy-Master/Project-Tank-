using System.Collections.Generic;
using UnityEngine;

public interface IHasLife
{
    void Hp();

}
public class TurretController : MonoBehaviour
{
    public Rigidbody2D rd2d;
    private Vector2 _movementVector;
    public float turretRotationSpeed;
    public Transform turretParent;
    private Transform _player;

    public float rechargeTimer;
    public float timerRecharge = 0.7f;
    
    private List<TankConlrollerIlya> _enemies = new List<TankConlrollerIlya>();

    public TowerGan towerGan;
    
    



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
                Quaternion.Euler(0, 0, desiredAngle - 90), rotatrionStep);

                if (_isRecharge == false)
                {
                    towerGan.Strike();
                    _isRecharge = true;
                    rechargeTimer = timerRecharge;
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
        if (other.gameObject.GetComponent<TankConlrollerIlya>() == null)
        {
            return;
        }
        
        _enemies.Add(other.gameObject.GetComponent<TankConlrollerIlya>());
        _player = ChoosingEnemy();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemies.Remove(other.gameObject.GetComponent<TankConlrollerIlya>());
        if (_enemies.Count > 0 && _player == other.gameObject.transform)
        {
            _player = ChoosingEnemy();
        }
    }

    Transform ChoosingEnemy()
    {
        float minHp = 999;
        TankConlrollerIlya tankCont = null;
        foreach (var variable in _enemies)
        {
            var hp = variable.HpPlayerManager;
            if (minHp > hp)
            {
                tankCont = variable;
                minHp = hp;
            }
        }

        if (tankCont is not null) return tankCont.transform;
        return null;
    }
}
