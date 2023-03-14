using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIPatrolStaticBehavior : MonoBehaviour, IAIPatrolStaticBehavior
{
    [SerializeField] private float _deltaPatrolDelay = 1;
    private float _patrolDelay;
    
    private Vector2 _randomDirection = Vector2.zero;
    private bool _newDirection = true;
    private bool _rotates;
    private void Awake()
    {
        _randomDirection = Random.insideUnitCircle;
    }
    

    public void PerformAction()
    {
        Vector2 turret = transform.position;
        var turretRotation = gameObject.GetComponent<ITurretRotation>();
        turretRotation.RotationTurret(turret + _randomDirection);
        if (_newDirection)
        {
            Debug.Log("r123");
            Invoke(nameof(NewDirection), _patrolDelay);
            _newDirection = false;
        }
    }
    private void NewDirection()
    {
        _randomDirection = Random.insideUnitCircle;
        Vector2 turret = transform.position;
        var angle = Vector2.Angle(turret + _randomDirection, transform.position + transform.right);
        if (angle < 60) _patrolDelay = 1 * _deltaPatrolDelay;
        else if (angle >= 60 && angle < 120 ) _patrolDelay = 2 * _deltaPatrolDelay;
        else _patrolDelay = 3 * _deltaPatrolDelay;
        _newDirection = true;
    }
}
