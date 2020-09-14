using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public static bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown, tap;
    private Vector2 StartTouch, SwipeDelta;
    private bool Dragging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tap = SwipeDown = SwipeUp = SwipeLeft = SwipeRight = false;
        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            Dragging = true;
            StartTouch = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Dragging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                Dragging = true;
                StartTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Dragging = false;
                Reset();
            }
        }
        #endregion
        SwipeDelta = Vector2.zero;
        if(Dragging)
        {
            if (Input.touches.Length < 0)
                SwipeDelta = Input.touches[0].position - StartTouch;
            else if (Input.GetMouseButton(0))
                SwipeDelta = (Vector2)Input.mousePosition - StartTouch;
        }
        if(SwipeDelta.magnitude > 100)
        {
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    SwipeLeft = true;
                }
                else
                {
                    SwipeRight = true;
                }
            }
            else
            {
                if (y < 0)
                    SwipeDown = true;
                else
                    SwipeUp = true;
            }
            Reset();
        }
    }
    private void Reset()
    {
        StartTouch = SwipeDelta = Vector2.zero;
        Dragging = false;
    }
}
