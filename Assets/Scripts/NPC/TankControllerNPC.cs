using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerNPC : MonoBehaviour
{
    private Transform _enemy;
    private IEnemyManager _turretEnemyManager;
    private ITurretRotation _turretRotation;
    private IGunsController _gunsController;
    private IAIPatrolStaticBehavior _aiPatrolStaticBehavior;

        private void Awake()
    {
        _turretEnemyManager = gameObject.GetComponentInChildren<IEnemyManager>();
        _turretRotation = gameObject.GetComponentInChildren<ITurretRotation>();
        _gunsController = gameObject.GetComponentInChildren<IGunsController>();
        _aiPatrolStaticBehavior = gameObject.GetComponentInChildren<IAIPatrolStaticBehavior>();
    }

    private void FixedUpdate()
    {
        _enemy = _turretEnemyManager.GetPositionEnemy();
        if (_enemy != null)
        {
            _turretRotation.RotationTurret(_enemy.position);
            _gunsController.GunsShoot();
        }
        else 
            _aiPatrolStaticBehavior.PerformAction();
        
    }
}

