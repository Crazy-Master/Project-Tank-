using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoverPlayer : MonoBehaviour
{

    public Rigidbody2D rd2d;
    private Vector2 movementVector;
    public float maxSpeed = 10; //скорость
    public float rotationSpeed = 100; //скорость вращения танка
    public ParticleSystem smokeEffect;
    private float smokeStep = 1;

    private void Awake()
    {
        rd2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move (Vector2 movementVector)
    {
        this.movementVector = movementVector;
        if (movementVector.x != 0 || movementVector.y != 0)
        {
            SmokeEffect(smokeStep, true);
        }
        else
        {
            SmokeEffect(smokeStep);
        }

    }

    private void FixedUpdate()
    {
        rd2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }

    private void SmokeEffect(float valueSmoke, bool gus = false)
    {
        var emission = smokeEffect.emission;
        if (!gus)
        {
            emission.rateOverTime = valueSmoke;
        }
        else
        {
            emission.rateOverTime = valueSmoke * 2f;
        }
    }

}
