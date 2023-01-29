using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpObject : MonoBehaviour
{
    private float _currentHpObject;

    public float HpObjectManager
    {
        get { return _currentHpObject; }
    
        set { _currentHpObject -=value;
            Debug.Log("damage=" + value);
    
            if (_currentHpObject<=0)
            {
                Destroy(gameObject);
            }
    
        } 
    }
}
