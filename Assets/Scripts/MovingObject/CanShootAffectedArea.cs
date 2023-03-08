using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//можно унаследовать для нпс!!!
    public class CanShootAffectedArea : MonoBehaviour ,ICanShoot
    {
        private Transform _turretParent;
        private float _desiredAngle;
        [SerializeField] private float Angle = 15;


        public bool CanShootNow()
        {
            _desiredAngle = gameObject.GetComponentInParent<TurretRotation>().desiredAngle;
            _turretParent = gameObject.GetComponentInParent<TurretRotation>().turretParent;
            if (Quaternion.Angle(_turretParent.rotation,Quaternion.Euler(0, 0, _desiredAngle)) < Angle)
            {
                return true;
            }
            return false;
        }
    }
