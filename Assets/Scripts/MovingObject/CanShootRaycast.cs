using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CanShootRaycast : MonoBehaviour ,ICanShoot
    {
        private RaycastHit2D _ray;
        private Transform _transform;
        [SerializeField] private LayerMask _pLayerLayerMask;

        public bool CanShootNow()
        {
            _ray = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, 1 << 8 | 1 << 11);
            //Debug.Log(_ray.collider);
            if (_ray.collider != null)
            {
                return (_pLayerLayerMask & (1 << _ray.collider.gameObject.layer)) != 0;
            }
            return false;
        }
    }