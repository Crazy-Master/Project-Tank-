using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Rigidbody2D rd2d;
    private Vector2 movementVector;
    public float turretRotationSpeed; //скорость вращения турели

    public Transform turretParent;
    public float fireDistans = 3.0f;
    [SerializeField] private Transform Player;

    public float rechargeTimer;
    public float timerRecharge = 1.5f;
    
    

    private bool isRecharge;
    //public float bulletDistance; 

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
    }

    public void FixedUpdate()
    {
        if (Vector2.Distance(turretParent.position, Player.position) < fireDistans)
        {
            var turretDirection = Player.position - turretParent.position;

            var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

            var rotatrionStep = turretRotationSpeed * Time.fixedDeltaTime;
            turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle - 90), rotatrionStep);
            
            if (isRecharge == false)
            {
                Debug.Log("Fire");
                isRecharge = true;
                rechargeTimer = timerRecharge;
            }
        }
        
        if (isRecharge)
        {
            rechargeTimer -= Time.deltaTime;
            if (rechargeTimer < 0)
                
                isRecharge = false;
        }
        
    }

}
