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
    private IAIPatrolStaticBehaviour _aiPatrolStaticBehavior;
    private Vector2 _vectorRandom;
    [SerializeField] private AIPatrolPathBehaviour _aiPatrolPathBehaviou;
        private void Awake()
    {
        _turretEnemyManager = gameObject.GetComponentInChildren<IEnemyManager>();
        _turretRotation = gameObject.GetComponentInChildren<ITurretRotation>();
        _gunsController = gameObject.GetComponentInChildren<IGunsController>();
        _aiPatrolStaticBehavior = gameObject.GetComponentInChildren<IAIPatrolStaticBehaviour>();
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
        {
            _vectorRandom = _aiPatrolStaticBehavior.PerformAction();
            _turretRotation.RotationTurret(_vectorRandom);
            _aiPatrolPathBehaviou.PerformAction();
        }
    }
}

