using UnityEngine;

    public interface IHpObject
    {
        public float CurrentHpObject();
        public void SetHeal(float heal);
        public void SetDamage(float damage);
    }
