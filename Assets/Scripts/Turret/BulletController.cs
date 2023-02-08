using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public BulletInfo bulletInfo;
    public float timer;

    private void Awake()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * bulletInfo.speedBullet, ForceMode2D.Impulse);
    }

    private void Start()
    {
        timer = bulletInfo.timerDestroy;
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
            hpObject.SetDamage(bulletInfo.bulletDamage);
        }
        Destroy(gameObject);
    }
}
