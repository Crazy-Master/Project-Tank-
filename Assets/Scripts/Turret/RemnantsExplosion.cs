using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RemnantsExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    private GameObject turret;
    void Start()
    {
        explosion.Play();
    }
    public void  DestroyTurret (GameObject turretObject)
    {
        turret = turretObject;
        Invoke("Destroy",1f);
    }

    public void Destroy()
    {
        Destroy(turret);
    }
}
