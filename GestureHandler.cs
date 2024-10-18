using UnityEngine;

public class GestureHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GestureManager.OnGestureDectected += HandleGesture;
    }
    private void OnDisable()
    {
        GestureManager.OnGestureDectected -= HandleGesture;
    }

    private void HandleGesture(GestureManager.GestureType type)
    {
        switch (type)
        {
            case GestureManager.GestureType.SwipeLeft:
                Debug.Log("Swipe Left Detected");
                break;
            case GestureManager.GestureType.SwipeRight:
                Debug.Log("Swipe Right Detected");
                break;

            case GestureManager.GestureType.SwipeUp:
                Debug.Log("Swipe Up Detected");
                break;
            case GestureManager.GestureType.SwipeDown:
                Debug.Log("Swipe Down Detected");
                break;
            case GestureManager.GestureType.Pinch:
                Debug.Log("Zoom Pinch Detected");
                break;
            case GestureManager.GestureType.Tap:
                Debug.Log("Tap Detected");
                break;
            case GestureManager.GestureType.LongPress:
                Debug.Log("Long Press Detected");
                break;

        }
    }
}
