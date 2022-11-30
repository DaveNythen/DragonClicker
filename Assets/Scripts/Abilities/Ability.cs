using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldownTime, activeTime;
    public SkillUI skillUI;
    [HideInInspector] public SkillUI skillUIInstance;

    public virtual void Activate(InputInfo inputInfo) {}
}
