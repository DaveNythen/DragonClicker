using System;
using UnityEngine;

public class AbilityTrigger: MonoBehaviour
{
    public enum AbilityTriggerType {none, touch, hold, drag, twoFingerHold};
    [HideInInspector] public AbilityTriggerType TriggerType;

    private InputInfo _inputInfo;

    private void OnEnable()
    {
        InputManager.OnTap += TouchTriggered;
        InputManager.OnPress += HoldTriggered;
        InputManager.OnDrag += DragTriggered;
        InputManager.OnPressTwoFingers += TwoFingerPressTriggered;
    }

    private void OnDisable()
    {
        InputManager.OnTap -= TouchTriggered;
        InputManager.OnPress -= HoldTriggered;
        InputManager.OnDrag -= DragTriggered;
        InputManager.OnPressTwoFingers -= TwoFingerPressTriggered;
    }

    private void TwoFingerPressTriggered(InputInfo inputInfo)
    {
        this._inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.twoFingerHold;
    }

    public void TouchTriggered(InputInfo inputInfo)
    {
        this._inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.touch;
    }

    public void HoldTriggered(InputInfo inputInfo)
    {
        this._inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.hold;
    }
    public void DragTriggered(InputInfo inputInfo)
    {
        this._inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.drag;
    }

    public InputInfo GetInputInfo()
    {
        return _inputInfo;
    }
}
