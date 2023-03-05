using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//можно унаследовать для нпс!!!
    public class CanShoot : MonoBehaviour, ICanShoot
    {
        private Transform _turretParent;
        private float _desiredAngle;
        private bool _isRecharge;
        [SerializeField] private float _timerRecharge = 0.5f;

        public void Start()
        {
            Debug.Log(AffectedArea()+ "" + _isRecharge);
        }

        public bool CanShootNow()
        {
            if (AffectedArea() && !_isRecharge) 
            {
                IsRecharge();
                return true; // перечисление методов
            }
            return false;
        }

        private bool AffectedArea()
        {
            _desiredAngle = gameObject.GetComponent<TurretRotation>().desiredAngle;
            _turretParent = gameObject.GetComponent<TurretRotation>().turretParent;
            if (Quaternion.Angle(_turretParent.rotation,Quaternion.Euler(0, 0, _desiredAngle)) < 15)
            {
                return true;
            }
            return false;
        }

        private void IsRecharge()
        {
            _isRecharge = true;
            Invoke(nameof(Recharge), _timerRecharge);
        }
        private void Recharge()
        {
            _isRecharge = false;
        }
    }
