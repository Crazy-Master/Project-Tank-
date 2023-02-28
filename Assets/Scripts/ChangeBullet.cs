using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBullet : MonoBehaviour
{

    [SerializeField] private BulletDataBase bulletDB;
    public EBullet _eBullet;
    private GunPlayer gunPlayer;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        TankMoverPlayer tankBase = other.GetComponent<TankMoverPlayer>();
        if(tankBase)
        {
            gunPlayer = tankBase.GetComponentInChildren<GunPlayer>();
            if (gunPlayer)
            {
                gunPlayer.bullet = _eBullet;
                Destroy(gameObject);
            }

        }

    }

}
