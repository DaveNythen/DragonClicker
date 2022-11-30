using System;
using System.Collections.Generic;
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

    public delegate void PressTwoFingersEvent(InputInfo inputInfo);
    public static event PressTwoFingersEvent OnPressTwoFingers;

    private float pressTime;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool isTwoFinger;
    private List<Finger> listOfFingers = new List<Finger>();

    private Vector3 accDir;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable(); //For testing from PC (2 finger)
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

    private void Update()
    {
        if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count == 2 && !isTwoFinger)
        {
            isTwoFinger = true;
            foreach (Finger finger in UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers)
            {
                if(!listOfFingers.Contains(finger))
                    listOfFingers.Add(finger);
            }
        }
        else
            isTwoFinger = false;

        ShakeInput();
    }

    private void FingerDown(Finger finger)
    {
        pressTime = Time.time;
        startPos = finger.screenPosition;
    }

    private void FingerUp(Finger finger)
    {
        endPos = finger.screenPosition;

        if (listOfFingers.Contains(finger))
        {
            listOfFingers.Remove(finger);

            if (finger.index != 0) //Only track the first touch
                return;

            TwoFingerGestures();
        }
        else
            OneFingerGestures();
    }

    private void TwoFingerGestures()
    {
        InputInfo inputInfo = new InputInfo(startPos, endPos);

        if (Vector3.Distance(startPos, endPos) > 50f)
        {
            //We're dragging
            
            return;
        }

        if (Time.time - pressTime > 0.2f)
        {
            //It's holding
            OnPressTwoFingers?.Invoke(inputInfo); //DEBUG
            return;
        }

        //It's a tap
    }

    private void OneFingerGestures()
    {
        InputInfo inputInfo = new InputInfo(startPos, endPos);

        if (Vector3.Distance(startPos, endPos) > 50f)
        {
            //We're dragging
            //Debug.Log($"Dragging? -> {startPos} and {endPos}, distance -> {Vector3.Distance(startPos, endPos)}");
            OnDrag?.Invoke(inputInfo);
            return;
        }

        if (Time.time - pressTime > 0.3f)
        {
            //It's holding
            OnPress?.Invoke(inputInfo);
            return;
        }

        //It's a tap
        OnTap?.Invoke(inputInfo);
    }

    private void ShakeInput()
    {
        accDir = Input.acceleration;

        if (accDir.sqrMagnitude >= 4f)
        {
            OnPressTwoFingers?.Invoke(new InputInfo(Vector2.zero, Vector2.zero));
        }
    }
}
