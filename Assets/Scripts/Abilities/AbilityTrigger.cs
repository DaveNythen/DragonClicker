using System;
using UnityEngine;

[RequireComponent(typeof(AbilityHolder))]
public class AbilityTrigger: MonoBehaviour
{
    public enum AbilityTriggerType {touch, hold, drag, twoFingerHold};
    [HideInInspector] public AbilityTriggerType TriggerType;

    private InputInfo _inputInfo;
    AbilityHolder _abilityHolder;

    private void Awake()
    {
        _abilityHolder = GetComponent<AbilityHolder>();
    }

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

    private void AbilityTriggered()
    {
        _abilityHolder.PlayAbility(TriggerType, _inputInfo);
    }

    private void TwoFingerPressTriggered(InputInfo inputInfo)
    {
        _inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.twoFingerHold;
        AbilityTriggered();
    }

    public void TouchTriggered(InputInfo inputInfo)
    {
        _inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.touch;
        AbilityTriggered();
    }

    public void HoldTriggered(InputInfo inputInfo)
    {
        _inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.hold;
        AbilityTriggered();
    }
    public void DragTriggered(InputInfo inputInfo)
    {
        _inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.drag;
        AbilityTriggered();
    }
}
