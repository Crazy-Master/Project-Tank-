using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float timerDestroy;

    private void Start()
    {
        timerDestroy = 5;
    }

    private void Update()
    {
        timerDestroy -= Time.deltaTime;
        if (timerDestroy < 0) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Destroy(gameObject);
    }
}
