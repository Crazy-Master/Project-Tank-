using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool _tap, _swipeLeft, _swipeRight, _swipeUp, _swipeDown;
    private bool _isDragins = false;
    private Vector2 _startTouch, _swipeDelta;

    private void Update()
    {
        _tap = _swipeLeft = _swipeRight = _swipeUp = _swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            _tap = true;
            _isDragins = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _tap = true;
                _isDragins = true;
                _startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }
        #endregion
        
        // Calculate the distance
        _swipeDelta = Vector2.zero;
        if (_isDragins)
        {
            if (Input.touches.Length > 0)
                _swipeDelta = Input.touches[0].position - _startTouch;
            else if (Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
            
        }
        
        // Did we cross the deadzone?
        if (_swipeDelta.magnitude > 125)
        {
            // Which direction?
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or right
                if (x < 0)
                    _swipeLeft = true;
                else
                    _swipeRight = true;
            }
            else
            {
                // Up or Down
                if (y < 0)
                    _swipeDown = true;
                else
                    _swipeUp = true;
            }
            Reset();
        }
        
    }

    public void Reset()
    {
        _isDragins = false;
        _startTouch = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }

    public Vector2 SwipeDelta { get { return _swipeDelta; } }
    public bool SwipeLeft { get { return _swipeLeft; } }
    public bool SwipeRight { get { return _swipeRight; } }
    public bool SwipeUp { get { return _swipeUp; } }
    public bool SwipeDown { get { return _swipeDown; } }
}
