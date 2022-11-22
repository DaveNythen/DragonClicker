using UnityEngine;

public class AbilityTrigger: MonoBehaviour
{
    public enum AbilityTriggerType {none, touch, hold, drag};
    [HideInInspector] public AbilityTriggerType TriggerType;

    private InputInfo inputInfo;

    private void OnEnable()
    {
        InputManager.OnTap += TouchTriggered;
        InputManager.OnPress += HoldTriggered;
        InputManager.OnDrag += DragTriggered;
    }

    private void OnDisable()
    {
        InputManager.OnTap -= TouchTriggered;
        InputManager.OnPress -= HoldTriggered;
        InputManager.OnDrag -= DragTriggered;
    }

    public void TouchTriggered(InputInfo inputInfo)
    {
        this.inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.touch;
    }

    public void HoldTriggered(InputInfo inputInfo)
    {
        this.inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.hold;
    }
    public void DragTriggered(InputInfo inputInfo)
    {
        this.inputInfo = inputInfo;
        TriggerType = AbilityTriggerType.drag;
    }

    public InputInfo GetInputInfo()
    {
        return inputInfo;
    }
}
