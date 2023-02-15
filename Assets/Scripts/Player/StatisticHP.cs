using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticHP : HpObject

{
    public ParticleSystem smokeEffect;
    private float smokeStep = 1;   //количество дыма

    
    public override void SetDamage(float damage)
    {
        base.SetDamage(damage);
        Debug.Log(damage);
        UI.instance.SetValue(_currentHpObject/_maxHp);
        smokeStep = _maxHp / _currentHpObject * 3;
        SmokeEffect(smokeStep);
      //  UI.instance.SetValue(_currentHpObject / (float)_maxHp);
    }
    public override void SetHeal(float heal)
    {
        base.SetHeal(heal);
        smokeStep = _maxHp / _currentHpObject * 3;
        SmokeEffect(smokeStep);
       // UI.instance.SetValue(_currentHpObject / (float)_maxHp);
        UI.instance.SetValue(_currentHpObject / _maxHp);
        // smokeStep = _maxHp / _currentHpObject * 3;
        // var emission = smokeEffect.emission;
        // emission.rateOverTime = smokeStep;
    }

    private void SmokeEffect(float valueSmoke, bool gus = false)
    {
        var emission = smokeEffect.emission;
        if (!gus)
        {
            emission.rateOverTime = valueSmoke;
        }
        else
        {
            emission.rateOverTime = valueSmoke * 2f;
        }
    }
}
