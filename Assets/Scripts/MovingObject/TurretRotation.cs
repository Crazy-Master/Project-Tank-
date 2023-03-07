using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour, ITurretRotation
{
    [SerializeField] private float turretRotationSpeed = 50;
    
    public Transform turretParent { get; private set; } //как реализовать интерфейс?
    public float desiredAngle { get; private set; }
    private Vector3 _turretDirection;
    private float _rotatrionStep;

    private void Awake()
    {
        turretParent = this.transform;
    }
    
    public void RotationTurret(Vector2 pointerPosition)
    {
        _turretDirection = (Vector3) pointerPosition - turretParent.position;
        
        desiredAngle = Mathf.Atan2(_turretDirection.y, _turretDirection.x) * Mathf.Rad2Deg;
        
        _rotatrionStep = turretRotationSpeed * Time.fixedDeltaTime;
        turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation,
            Quaternion.Euler(0, 0, desiredAngle), _rotatrionStep);
    }
}

