using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder (-1)]
public class InputManager : MonoBehaviour
{
    public delegate void TapEvent (InputInfo inputInfo);
    public static event TapEvent OnTap;

    public delegate void PressEvent (InputInfo inputInfo);
    public static event PressEvent OnPress;

    public delegate void DragEvent(InputInfo inputInfo);
    public static event DragEvent OnDrag;

    private float pressTime;
    private Vector2 startPos;
    private Vector2 endPos;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable(); //For testing from PC (1 finger)
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerUp;
    }

    private void OnDisable()
    { 
        EnhancedTouchSupport.Disable();
        TouchSimulation.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= FingerUp;
    }

    private void FingerDown(Finger finger)
    {
        //if (OnTap != null) OnTap(finger.currentTouch);
        pressTime = Time.time;
        startPos = finger.screenPosition;
    }

    private void FingerUp(Finger finger)
    {
        endPos = finger.screenPosition;

        InputInfo inputInfo = new InputInfo(startPos, endPos);
        
        if (Vector3.Distance(startPos, endPos) > 50f) 
        {
            //We're dragging
            //Debug.Log($"Dragging? -> {startPos} and {endPos}, distance -> {Vector3.Distance(startPos, endPos)}");
            if (OnDrag != null) OnDrag(inputInfo);
            return;
        }

        if (Time.time - pressTime > 0.3f)
        {
            //It's holding
            if(OnPress != null) OnPress(inputInfo);
            return;
        }

        //It's a tap
        if (OnTap != null) OnTap(inputInfo);
    }
}
