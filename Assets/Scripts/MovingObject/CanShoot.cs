using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//можно унаследовать для нпс!!!
    public class CanShoot : MonoBehaviour, ICanShoot
    {
        protected bool _isRecharge;
        [SerializeField] private float _timerRecharge = 0.5f;
        

        public virtual bool CanShootNow()
        {
            if (!_isRecharge)  // перечисление методов
            {
                IsRecharge();
                return true;
            }
            return false;
        }
        

        protected void IsRecharge()
        {
            _isRecharge = true;
            Invoke(nameof(Recharge), _timerRecharge);
        }
        private void Recharge()
        {
            _isRecharge = false;
        }
    }
