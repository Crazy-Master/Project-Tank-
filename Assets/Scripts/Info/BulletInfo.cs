using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletInfo", menuName = "Gameplay/New BulletInfo")]
public class BulletInfo : ScriptableObject
{
    [SerializeField] private float _timerDestroy;
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _bulletDamage;

    public float timerDestroy => this._timerDestroy;
    public float speedBullet => this._speedBullet;
    public float bulletDamage => this._bulletDamage;
}
