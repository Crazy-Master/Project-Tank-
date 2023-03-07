using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsController : MonoBehaviour, IGunsController
{
    [SerializeField] private GunController[] _guns;

    private void Awake()
    {
        if (_guns == null || _guns.Length == 0)
        {
            _guns = GetComponentsInChildren<GunController>();
        }
    }
    public void GunsShoot()
    {
        foreach (var guns in _guns)
        {
            guns.Shoot();
        }
    }
}
