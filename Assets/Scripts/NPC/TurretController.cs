using System.Collections.Generic;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    //private Vector2 _movementVector;
    private Transform _enemy;
    [SerializeField] private EnemyManager _turretEnemyManager;

    public void FixedUpdate()
    {
        _enemy = _turretEnemyManager.GetPositionEnemy();
        if (_enemy != null)
            {
                gameObject.GetComponentInChildren<ITurretRotation>().RotationTurret(_enemy.position);
                gameObject.GetComponentInChildren<IGunsController>().GunsShoot();
            }
        
    }
}
