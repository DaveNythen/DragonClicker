using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillUI : MonoBehaviour
{
    [SerializeField] Image _fill;

    public float cooldownTime;
    public float activeTime;

    public void DisplaySkillTimers()
    {
        DisplayActiveTime();
    }

    void DisplayActiveTime()
    {
        //Decrease fill by time
        _fill.DOFillAmount(0, activeTime).SetEase(Ease.Linear)
            .OnComplete(DisplayCooldown);
    }

    void DisplayCooldown()
    {
        //Fill image by time
        _fill.DOFillAmount(1, cooldownTime - activeTime).SetEase(Ease.Linear);
    }
}
