using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankBaseNPS : HpObject
{
    [SerializeField] private GameObject _objectTank;
    [SerializeField] private GameObject _remnants;

    public override void SetDamage(float damage)
    {
        _currentHpObject -= damage;
        if (_currentHpObject <= 0)
        {
            GameObject remnantsObject = Instantiate(_remnants, _objectTank.transform.position, _objectTank.transform.rotation);
            remnantsObject.GetComponent<RemnantsExplosion>().DestroyTurret(_objectTank);
        }
    
    }
    
}
