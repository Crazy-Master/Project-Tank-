using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public EBullet _eBullet;
    public GameObject creatorObject;
    private Rigidbody2D _rb2d;
    [SerializeField] private BulletDataBase bulletDB;
    private float _timer;
    private GameObject[] _h;
    

    

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _timer = bulletDB.GetTimeLife(_eBullet);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        HpObject hpObject = other.gameObject.GetComponent<HpObject>();
        if (other.gameObject == creatorObject)
        {
            return;
        }
        if (hpObject)
        {
            hpObject.SetDamage(bulletDB.GetDamage(_eBullet));
        }
        gameObject.SetActive(false);
    }

    public void AddForceBullet()
    {
        _rb2d.velocity = new Vector3(0, 0, 0);
        _rb2d.AddForce(transform.up * bulletDB.GetSpeed(_eBullet), ForceMode2D.Impulse);
        _timer = bulletDB.GetTimeLife(_eBullet);
    }
}
