using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHpManager : HpObject
{
    public GameObject platform;
    public GameObject remnants;
    public override void SetDamage(float damage)
    {
        _currentHpObject -= damage;
        if (_currentHpObject <= 0)
        {
            GameObject remnantsObject = Instantiate(remnants, platform.transform.position, platform.transform.rotation);
            remnantsObject.GetComponent<RemnantsExplosion>().DestroyTurret(platform);
        }
    
    }
}
