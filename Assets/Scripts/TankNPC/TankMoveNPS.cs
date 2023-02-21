using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveNPS : MonoBehaviour
{
    public Rigidbody2D rd2d;

    public float maxSpeed = 100;
    public float rotationSpeed = 10;
    
    public Animator trackLeft;
    public Animator trackRigth;

    private Vector2 _movementVector;
    
    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }
    
    public void MoveBase(Vector2 movementVector)
    {
        _movementVector = movementVector;
        rd2d.velocity = (Vector2)transform.up * _movementVector.y * maxSpeed * Time.fixedDeltaTime;
        if (_movementVector.y < 0)
        {
            rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, _movementVector.x * rotationSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -_movementVector.x * rotationSpeed * Time.fixedDeltaTime));
        }
        
    }

    public void Update()
    {
        if (_movementVector != new Vector2(0, 0))
        {
            IsMoving(true);
        }
        else
        {
            IsMoving(false);
        }
    }
    
    private void IsMoving(bool isMoving)
    {
        trackLeft.SetBool("IsMoving", isMoving);
        trackRigth.SetBool("IsMoving", isMoving);
    }


}
