using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder (-1)]
public class InputManager : Singleton<InputManager>
{
    public delegate void TapEvent (InputInfo inputInfo);
    public static event TapEvent OnTap;

    public delegate void PressEvent (InputInfo inputInfo);
    public static event PressEvent OnPress;

    public delegate void DragEvent(InputInfo inputInfo);
    public static event DragEvent OnDrag;

    public delegate void PressTwoFingersEvent(InputInfo inputInfo);
    public static event PressTwoFingersEvent OnPressTwoFingers;

    private float _pressTime;
    private Vector2 _startPos;
    private Vector2 _endPos;
    private bool _isTwoFinger;
    private List<Finger> _listOfFingers = new List<Finger>();

    private Vector3 _accDir;

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
        if (GameStatus.IsPaused) return;

        if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count == 2 && !_isTwoFinger)
        {
            _isTwoFinger = true;
            foreach (Finger finger in UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers)
            {
                if(!_listOfFingers.Contains(finger))
                    _listOfFingers.Add(finger);
            }
        }
        else
            _isTwoFinger = false;

        ShakeInput();
    }

    private void FingerDown(Finger finger)
    {
        _pressTime = Time.time;
        _startPos = finger.screenPosition;
    }

    private void FingerUp(Finger finger)
    {
        if (GameStatus.IsPaused) return;

        _endPos = finger.screenPosition;

        if (_listOfFingers.Contains(finger))
        {
            _listOfFingers.Remove(finger);

            if (finger.index != 0) //Only track the first touch
                return;

            TwoFingerGestures();
        }
        else
            OneFingerGestures();
    }

    private void TwoFingerGestures()
    {
        InputInfo inputInfo = new InputInfo(_startPos, _endPos);

        if (Vector3.Distance(_startPos, _endPos) > 50f)
        {
            //We're dragging
            
            return;
        }

        if (Time.time - _pressTime > 0.2f)
        {
            //It's holding
#if UNITY_EDITOR
            OnPressTwoFingers?.Invoke(inputInfo); //DEBUG
#endif
            return;
        }

        //It's a tap
    }

    private void OneFingerGestures()
    {
        InputInfo inputInfo = new InputInfo(_startPos, _endPos);

        if (Vector3.Distance(_startPos, _endPos) > 50f)
        {
            //We're dragging
            OnDrag?.Invoke(inputInfo);
            return;
        }

        if (Time.time - _pressTime > 0.3f)
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
        _accDir = Input.acceleration;

        if (_accDir.sqrMagnitude >= 4f)
        {
            //is a global skill, I don't need the Input position
            OnPressTwoFingers?.Invoke(new InputInfo(Vector2.zero, Vector2.zero));
        }
    }
}
