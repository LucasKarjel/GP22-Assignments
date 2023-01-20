using UnityEngine;
using System.Collections;

public class ReadTouch : MonoBehaviour
{
    private void OnEnable()
    {
        // Subcribe to events when object is enabled
        TouchManager.OnTouchDown += OnTouchDown;
        TouchManager.OnTouchUp += OnTouchUp;
        TouchManager.OnTouchDrag += OnTouchDrag;
    }

    private void OnDisable()
    {
        // Unsubcribe from events when object is disabled
        TouchManager.OnTouchDown -= OnTouchDown;
        TouchManager.OnTouchUp -= OnTouchUp;
        TouchManager.OnTouchDrag -= OnTouchDrag;
    }

    private void OnTouchDown(Touch eventData)
    {
        Debug.Log("OnTouchDown!");
    }

    private void OnTouchUp(Touch eventData)
    {
        Debug.Log("OnTouchUp!");
    }

    private void OnTouchDrag(Touch eventData)
    {
        Debug.Log("OnTouchDrag");
    }
}
