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
    public float speedBullet;

    public Transform turretParent;
    public Transform firePoint;

    public GameObject projectilePrefab;

    private float _currentHp=100;
   

    public float HpPlayerManager
    {
        get { return _currentHp; }

        set { _currentHp -=value;
            Debug.Log("damage=" + value);

            if (_currentHp<0)
            {
                Destroy(gameObject);
            }

        } 
    }

   
    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

   
    private float SetHpPlayer (float hp)
    {
        return hp;
    }

    public void HandleShoot()
    {
        GameObject projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        var bullet = projectileOdject.GetComponent<Rigidbody2D>();
     //   var bulletStart = projectileOdject.GetComponent<ProjectileIlya>();
     //   bulletStart.bulletStartPos = this.transform;
        bullet.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
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
