using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public EBullet _eBullet;
    public TankBaseNPS creatorObject = null;
    private Rigidbody2D rb2d;
    [SerializeField] private BulletDataBase bulletDB;
    private float timer;
    

    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        HpObject hpObject = other.gameObject.GetComponent<HpObject>();
        if (hpObject != creatorObject)
        {
            if (hpObject)
            {
                hpObject.SetDamage(bulletDB.GetDamage(_eBullet));
            }
            gameObject.SetActive(false);
        }
    }

    public void AddForceBullet()
    {
        rb2d.velocity = new Vector3(0, 0, 0);
        rb2d.AddForce(transform.up * bulletDB.GetSpeed(_eBullet), ForceMode2D.Impulse);
        timer = bulletDB.GetTimeLife(_eBullet);
    }
}
