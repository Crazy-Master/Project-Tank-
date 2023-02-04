using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float timerDestroy = 5f;
    

    public float bulletDamageTurret = 5f;
    

    private void Update()
    {
        timerDestroy -= Time.deltaTime;
        if (timerDestroy < 0) Destroy(gameObject);
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        //if (other.gameObject.CompareTag("Damaged"))
        HpObject hpObject = other.gameObject.GetComponent<HpObject>();
        if (hpObject)
        {
            hpObject.SetDamage(bulletDamageTurret);
        }
        Destroy(gameObject);
    }
}
