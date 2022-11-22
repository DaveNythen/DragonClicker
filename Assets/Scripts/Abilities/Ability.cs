using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldownTime, activeTime;

    public virtual void Activate(InputInfo inputInfo) {}
}
