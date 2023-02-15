using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletDataBase bulletDB;
    private EBullet _eBullet;
    private float timer;

    private void Awake()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * bulletDB.GetSpeed(_eBullet), ForceMode2D.Impulse);
    }

    private void Start()
    {
        timer = bulletDB.GetTimeLife(_eBullet);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) Destroy(gameObject);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        HpObject hpObject = other.gameObject.GetComponent<HpObject>();
        if (hpObject)
        {
            hpObject.SetDamage(bulletDB.GetDamage(_eBullet));
        }
        Destroy(gameObject);
    }
}
