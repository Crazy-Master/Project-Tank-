using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 _desiredPosition;

    private void Update()
    {
        if (swipeControls.SwipeLeft) 
            _desiredPosition += Vector3.left;
        if (swipeControls.SwipeRight) 
            _desiredPosition += Vector3.right;
        if (swipeControls.SwipeUp) 
            _desiredPosition += Vector3.forward;
        if (swipeControls.SwipeDown) 
            _desiredPosition += Vector3.back;

        player.transform.position = Vector3.MoveTowards(player.transform.position, _desiredPosition, 3f * Time.deltaTime);
    }
}
