using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemnantsExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    void Start()
    {
        explosion.Play();
    }
}
