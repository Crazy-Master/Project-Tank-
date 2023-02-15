using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoverPlayer : MonoBehaviour
{

    public Rigidbody2D rd2d;
    private Vector2 movementVector;
    public float maxSpeed = 10; //скорость
    public float rotationSpeed = 100; //скорость вращения танка


    private void Awake()
    {
        rd2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move (Vector2 movementVector)
    {
        this.movementVector = movementVector;

    }

    private void FixedUpdate()
    {
        rd2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
