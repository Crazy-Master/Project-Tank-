using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankConlrollerIlya : MonoBehaviour
{

    public Rigidbody2D rd2d;
    private Vector2 movementVector;
    public float maxSpeed = 10; //скорость
    public float rotationSpeed = 100; //скорость вращения танка
    public float turretRotationSpeed = 150; //скорость вращения турели

    public Transform turretParent;

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting");
    }


    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - turretParent.position;

        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

        var rotatrionStep = turretRotationSpeed * Time.deltaTime;
        turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle-90), rotatrionStep);
    }

    private void FixedUpdate()
    {
        rd2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
