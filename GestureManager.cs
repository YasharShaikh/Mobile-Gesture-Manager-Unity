using System;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    public enum GestureType
    {
        None, SwipeLeft, SwipeRight, SwipeUp, SwipeDown, Pinch, Tap, LongPress
    }

    public static event Action<GestureType> OnGestureDectected;

    [SerializeField] float swipeThreshold = 50.0f;
    [SerializeField] float tapThreshold = 0.2f;
    [SerializeField] float longPressThreshold = 0.8f;

    Vector2 startTouchPosition;
    Vector2 lastTouchPosition;
    float touchStartTime;
    bool isTouching = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchBegan(touch);
                    break;

                case TouchPhase.Moved:
                    OnTouchMoved(touch);
                    break;

                case TouchPhase.Ended:
                    OnTouchEnded(touch);
                    break;
            }
        }
        else if (Input.touchCount == 2)
            DetectPinch();
    }



    private void OnTouchBegan(Touch touch)
    {
        isTouching = true;
        startTouchPosition = touch.position;
        touchStartTime = Time.time;
    }

    private void OnTouchMoved(Touch touch)
    {
        if (isTouching)
            DetectSwipe(touch);
    }


    private void OnTouchEnded(Touch touch)
    {
        isTouching = false;
        DetectTaporLongPress(touch);
    }

    private void DetectSwipe(Touch touch)
    {
        lastTouchPosition = touch.position;
        Vector2 swipeDelta = lastTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude > swipeThreshold)
        {
            //horizontal swipe
            if (Mathf.Abs(swipeDelta.x) > MathF.Abs(swipeDelta.y))
            {
                if (swipeDelta.x > 0)
                    OnGestureDectected?.Invoke(GestureType.SwipeRight);
                else
                    OnGestureDectected?.Invoke(GestureType.SwipeLeft);
            }
            // Vertical swipe
            else
            {
                if (swipeDelta.y > 0)
                    OnGestureDectected?.Invoke(GestureType.SwipeUp);
                else
                    OnGestureDectected?.Invoke(GestureType.SwipeDown);
            }
        }
    }

    private void DetectTaporLongPress(Touch touch)
    {
        float touchDuration = Time.time - touchStartTime;

        if (touchDuration <= tapThreshold)
            OnGestureDectected?.Invoke(GestureType.Tap);
        else if (touchDuration >= longPressThreshold)
            OnGestureDectected?.Invoke(GestureType.LongPress);
    }
    private void DetectPinch()
    {
        Touch touch0 = Input.GetTouch(0);
        Touch touch1 = Input.GetTouch(1);

        Vector2 prevPos0 = touch0.position - touch0.position;
        Vector2 prevPos1 = touch1.position - touch1.position;

        float prevDistance = Vector2.Distance(prevPos0, prevPos1);
        float currentDisntace = Vector2.Distance(touch0.position, touch1.position);

        float pinchDelta = prevDistance - currentDisntace;

        if (Mathf.Abs(pinchDelta) > tapThreshold)
            OnGestureDectected?.Invoke(GestureType.Pinch);
    }
}
