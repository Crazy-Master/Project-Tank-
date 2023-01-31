using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileIlya : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // public Transform bulletStartPos;
    public float bulletDamage = 5f;
    
    void Start()
    {
        
       //rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HpObject hpObject = other.gameObject.GetComponent<HpObject>();
        if (hpObject)
        {
            hpObject.SetDamage(bulletDamage);
        }
        Destroy(gameObject);
    }

    private void Update()
    {
       // float dist = Vector2.Distance(transform.position, bulletStartPos.position);
       // Debug.Log(dist);
       // if (dist>20)
       // {
       //     Destroy(gameObject);
       // }
    }
}
