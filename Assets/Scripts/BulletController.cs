using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float timerDestroy;
    

    public float bulletDamageTurret = 5f;

    private void Awake()
    {
        timerDestroy = 5;
        
    }

    private void Update()
    {
        timerDestroy -= Time.deltaTime;
        if (timerDestroy < 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        
        // if (other.gameObject.CompareTag("Damaged"))
        // {
        //     other.gameObject.GetComponent<TankConlrollerIlya>().HpPlayerManager=bulletDamageTurret;
        // }
        // Destroy(gameObject);
    }
}
