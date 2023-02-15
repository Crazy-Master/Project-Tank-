using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EBullet
{
    Standart,
    Speedy
}

[Serializable]
public class BulletSetting
{
    public EBullet bulletName;
    public float speed;
    public float damage;
    public float timeLife;
}

[CreateAssetMenu(fileName = "BulletDataBase", menuName = "Gameplay/New BulletDataBase")]
public class BulletDataBase : ScriptableObject
{
    [SerializeField] List<BulletSetting> bulletSettings;
    public List<BulletSetting> SettingBullet => bulletSettings;
    public float GetSpeed(EBullet bullet)
    {
        for (int i = 0; i < SettingBullet.Count; i++)
        {
            if (SettingBullet[i].bulletName==bullet)
            {
                return SettingBullet[i].speed;
            }
        }

        return 2f;
    }

    public float GetDamage(EBullet bullet)
    {
        for (int i = 0; i < SettingBullet.Count; i++)
        {
            if (SettingBullet[i].bulletName == bullet)
            {
                return SettingBullet[i].damage;
            }
        }

        return 10f;
    }

    public float GetTimeLife(EBullet bullet)
    {
        for (int i = 0; i < SettingBullet.Count; i++)
        {
            if (SettingBullet[i].bulletName == bullet)
            {
                return SettingBullet[i].timeLife;
            }
        }

        return 8f;
    }
}
