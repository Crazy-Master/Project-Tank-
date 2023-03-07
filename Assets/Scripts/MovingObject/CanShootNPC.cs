using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//можно унаследовать для нпс!!!
    public class CanShootNPC : CanShoot, ICanShoot
    {
        private Transform _turretParent;
        private float _desiredAngle;



        public override bool CanShootNow()
        {
            if (AffectedArea() && !_isRecharge)  // перечисление методов
            {
                IsRecharge();
                return true;
            }
            return false;
        }

        private bool AffectedArea()
        {
            _desiredAngle = gameObject.GetComponentInParent<TurretRotation>().desiredAngle;
            _turretParent = gameObject.GetComponentInParent<TurretRotation>().turretParent;
            if (Quaternion.Angle(_turretParent.rotation,Quaternion.Euler(0, 0, _desiredAngle)) < 15)
            {
                return true;
            }
            return false;
        }
    }
