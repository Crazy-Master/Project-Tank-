using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHorizontalMovement : MonoBehaviour
{
    [SerializeField] private Swipe _swipeControls;
    private Vector3 _desiredPosition;

    [SerializeField] private HorizontalMovement _horizontalMovement;
    public HorizontalMovement horizontalMovement => _horizontalMovement;
    [SerializeField] private MovementButtons _movementButtons;
    [SerializeField] private BehaviorPlayerMove _behaviorPlayerMove;
    
    private void Update()
    {
        if (_swipeControls.SwipeLeft) 
            _horizontalMovement.HorizontalButtons(-1);
        if (_swipeControls.SwipeRight) 
            _horizontalMovement.HorizontalButtons(+1);
        if (_swipeControls.SwipeUp)
        {
            _movementButtons.ButtonsMovement();
            _behaviorPlayerMove.CanGoStep = true;
            enabled = false;
        }
    }
    
}
