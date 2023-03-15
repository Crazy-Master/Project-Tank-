using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolPathBehaviour : MonoBehaviour
{
    public PatrolPath patrolPath;
    [Range(0.1f, 1)] public float arriveDistanse = 1;
    public float waittime = 0.5f;
    [SerializeField] private bool isWaiting;
    [SerializeField] private Vector2 currentPatrolTarget = Vector2.zero;
    private bool isInitilized;

    private int currentIndex = -1;

    
    [SerializeField] private ITankMoveController _tankMoveNps;
    private void Awake()
    {
        if (patrolPath == null)
            patrolPath = GetComponentInChildren<PatrolPath>();
        if (_tankMoveNps == null)
            _tankMoveNps = GetComponentInChildren<ITankMoveController>();
    }

    public void PerformAction()
    {
        if (!isWaiting)
        {
            if (patrolPath.Length > 2)
                return;
            if (!isInitilized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(transform.position);
                this.currentIndex = currentPathPoint.indexStruct;
                this.currentPatrolTarget = currentPathPoint.positionStruct;
                isInitilized = true;
            }

            if (Vector2.Distance(transform.position, currentPatrolTarget) < arriveDistanse)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }

            Vector2 directionToGo = currentPatrolTarget - (Vector2)transform.position;
            var dotProduct = Vector2.Dot(transform.up, directionToGo.normalized);

            if (dotProduct < 0.98f)
            {
                var crossProduct = Vector3.Cross(transform.up, directionToGo.normalized);
                int rotationResult = crossProduct.z >= 0 ? -1 : 1;
                _tankMoveNps.Move(new Vector2(rotationResult, 1));
            }
            else
            {
                _tankMoveNps.Move(Vector2.up);
            }
        }

        IEnumerator WaitCoroutine()
        {
            var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
            currentPatrolTarget = nextPathPoint.positionStruct;
            currentIndex = nextPathPoint.indexStruct;
            isWaiting = false;
            return null;
        }
    }
}
