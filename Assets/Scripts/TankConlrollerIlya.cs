using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankConlrollerIlya : HpObject
{

    public Rigidbody2D rd2d;
    private Vector2 movementVector;
    public float maxSpeed = 10; //скорость
    public float rotationSpeed = 100; //скорость вращения танка
    public float turretRotationSpeed = 150; //скорость вращения турели
    public float speedBullet;
    private float smokeStep=1;   //количество дыма

    public Transform turretParent;
    public Transform firePoint;

    public GameObject projectilePrefab;
    public ParticleSystem smokeEffect;
    
    


   
    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }
    

    public void HandleShoot()
    {
        GameObject projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        var bullet = projectileOdject.GetComponent<Rigidbody2D>();
        bullet.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
        Debug.Log("Shooting");
        
    }
    

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector; 
        if (movementVector.x !=0 || movementVector.y !=0)
        {
            SmokeEffect(smokeStep,true);
        }    
        else
        {
            SmokeEffect(smokeStep);
        }    
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

    public override void SetDamage(float damage)
    {
        base.SetDamage(damage);
        //  UI.instance.SetValue(_currentHpObject/_maxHp);
        smokeStep = _maxHp / _currentHpObject*3;
        SmokeEffect(smokeStep);
    }
    public override void SetHeal(float heal)
    {
        base.SetHeal (heal);
        //  UI.instance.SetValue(_currentHpObject / _maxHp);
       // smokeStep = _maxHp / _currentHpObject * 3;
       // var emission = smokeEffect.emission;
       // emission.rateOverTime = smokeStep;
    }

    private void SmokeEffect (float valueSmoke, bool gus=false)
    {
        var emission = smokeEffect.emission;
        if (!gus)
        {
            emission.rateOverTime = valueSmoke;
        }
        else
        {
            emission.rateOverTime = valueSmoke*10f;
        }
    }
}

