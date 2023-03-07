using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHpManager : HpObject
{
    //[SerializeField] private GameObject _gameObject; реализовать класс DestroyObject
    //[SerializeField] private GameObject _remnants; //создается на месте главного объекта, а не подобъекта
    // public override void SetDamage(float damage)
    // {
    //     _currentHpObject -= damage;
    //     if (_currentHpObject <= 0)
    //     {
    //         GameObject remnantsObject = Instantiate(_remnants, _gameObject.transform.position, _gameObject.transform.rotation);
    //         remnantsObject.GetComponent<RemnantsExplosion>().DestroyTurret(_gameObject);
    //     }
    // }
}
