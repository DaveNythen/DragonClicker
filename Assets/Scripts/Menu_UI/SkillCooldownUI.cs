using UnityEngine;

public class SkillCooldownUI : MonoBehaviour
{
    [SerializeField] AbilityHolder _abilityHolder;

    private void Start()
    {
        foreach (var abilityAndTrigger in _abilityHolder.abilitiesTriggers)
        {
            Ability ability = abilityAndTrigger.ability;

            SkillUI skillUI = Instantiate(ability.skillUI, transform);
            skillUI.cooldownTime = ability.cooldownTime;
            skillUI.activeTime = ability.activeTime;

            ability.skillUIInstance = skillUI; //Reference the instance
        }
    }
}
