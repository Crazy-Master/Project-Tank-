//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NPCTankRadar : MonoBehaviour
//{
//    public GameObject NPSTankTurret;
//    private List<HpObject> _enemies = new List<HpObject>();
//    private Transform _player;



//    void Start()
//    {
        
//    }


//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.GetComponent<HpObject>() == null || other.gameObject == NPSTankTurret)
//        {
//            return;
//            Debug.Log("132");
//        }

//        _enemies.Add(other.gameObject.GetComponent<HpObject>());
//        _player = ChoosingEnemy();
//    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        _enemies.Remove(other.gameObject.GetComponent<HpObject>());
//        if (_enemies.Count > 0 && _player == other.gameObject.transform || other.gameObject == NPSTankTurret)
//        {
//            _player = ChoosingEnemy();
//        }
//    }

//    Transform ChoosingEnemy()
//    {
//        float minHp = 9999;
//        HpObject tankCont = null;
//        foreach (var variable in _enemies)
//        {
//            var hp = variable.HpObjectManager;
//            if (minHp > hp)
//            {
//                tankCont = variable;
//                minHp = hp;
//            }
//        }

//        if (tankCont is not null) return tankCont.transform;
//        return null;
//    }
//}
