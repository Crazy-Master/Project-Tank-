using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyManager : MonoBehaviour
{
    private Vector2 _movementVector;
    public Transform _enemy
    {
        get; 
        private set;
    }
    private List<HpObject> _enemies = new List<HpObject>();

    [SerializeField] private GameObject towerTurret;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HpObject>() == null || other.gameObject == towerTurret)
        {
            return;
        }
        
        _enemies.Add(other.gameObject.GetComponent<HpObject>());
        _enemy = ChoosingEnemy();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemies.Remove(other.gameObject.GetComponent<HpObject>());
        if (_enemy == other.gameObject.transform || other.gameObject == towerTurret)
        {
            if (_enemies.Count > 0) _enemy = ChoosingEnemy();
            _enemy = null;
        }
    }
    
    private Transform ChoosingEnemy()
    {
        float minHp = 9999;
        HpObject tankCont = null;
        foreach (var variable in _enemies)
        {
            var hp = variable.HpObjectManager;
            if (minHp > hp)
            {
                tankCont = variable;
                minHp = hp;
            }
        }

        if (tankCont is not null) return tankCont.transform;
        return null;
    }
}
