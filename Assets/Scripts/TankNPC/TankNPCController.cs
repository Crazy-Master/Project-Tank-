using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankNPCController : MonoBehaviour
{
    public Rigidbody2D rd2d;
    private Vector2 movementVector;
    public float maxSpeed = 10; //скорость
    public float rotationSpeed = 100; //скорость вращения танка
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    
    public Animator trackLeft;
    public Animator trackRigth;
    
    public float magnitudeX;
    private void Awake()
    {
       rd2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //magnitudeX = rd2d.velocity.magnitude;
        Debug.Log(magnitudeX);
        //rd2d.velocity = (Vector2)transform.up * 2 * maxSpeed * Time.fixedDeltaTime;
        //rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
        transform.position = Vector2.MoveTowards(transform.position, player.position, maxSpeed * Time.deltaTime);
        
        trackLeft.SetFloat("IsMoving" , 2f);
        trackRigth.SetFloat("IsMoving" , 2f);
    }
}
