using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretNPS : MonoBehaviour
{
    public float turretRotationSpeed = 100;

    [SerializeField] private Transform _turretParent;
    
    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - _turretParent.position;
    
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
    
        var rotatrionStep = turretRotationSpeed * Time.deltaTime;
        _turretParent.rotation = Quaternion.RotateTowards(_turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle), rotatrionStep);
    }
}
