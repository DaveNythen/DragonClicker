using UnityEngine;

public class SkillCooldownUI : MonoBehaviour
{
    [SerializeField] AbilityHolder _abilityHolder;

    private void Start()
    {
        DisplayUnclockedAbilitiesUI();
    }

    private void DisplayUnclockedAbilitiesUI()
    {
        foreach (AbilityHolder.AbilityAndTrigger abilityAndTrigger in _abilityHolder.abilitiesTriggers)
        {
            Ability ability = abilityAndTrigger.ability;

            if (!SaveData.Instance.profile.unlockedAbilitiesIDs.Contains(ability.id)) return;

            SkillUI skillUI = Instantiate(ability.skillUI, transform);
            skillUI.cooldownTime = ability.cooldownTime;
            skillUI.activeTime = ability.activeTime;

            ability.skillUIInstance = skillUI; //Reference the instance
        }
    }
}
