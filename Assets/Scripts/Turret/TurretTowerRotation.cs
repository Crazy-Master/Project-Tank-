using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTowerRotation : MonoBehaviour
{
    public Rigidbody2D rd2d;
    private Vector2 _movementVector;
    public float turretRotationSpeed;
    public Transform turretParent;
    private Transform _enemy;
    private bool _isRecharge;

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }


    public void FixedUpdate()
    {
       // if (_enemies.Count > 0)
        {
            if (_enemy != null)
            {
                var turretDirection = _enemy.position - turretParent.position;

                var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

                var rotatrionStep = turretRotationSpeed * Time.fixedDeltaTime;
                turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation,
                    Quaternion.Euler(0, 0, desiredAngle), rotatrionStep);
            }
        }
    }
}

