using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [Serializable]
    public struct AbilityAndTrigger //Fake Dictionary to fill values on Inspector
    {
        public Ability ability;
        public AbilityTrigger.AbilityTriggerType triggerType;
    }

    public AbilityAndTrigger[] abilitiesTriggers;

    Ability _currentAbility;
    private List<Ability> _cooldownAbilities;

    private AbilityTrigger _abilityTrigger;

    private void Awake()
    {
        _abilityTrigger = FindObjectOfType<AbilityTrigger>();
        _cooldownAbilities = new List<Ability>();
    }

    void Update()
    {
        foreach (var ability in abilitiesTriggers)
        {
            if (_abilityTrigger.TriggerType == ability.triggerType)
            {
                _currentAbility = ability.ability;

                if (_cooldownAbilities.Contains(_currentAbility)) return;

                _currentAbility.Activate(_abilityTrigger.GetInputInfo());
                _abilityTrigger.TriggerType = AbilityTrigger.AbilityTriggerType.none;

                StartCoroutine(SetAbilityOnCooldown(_currentAbility));
                UpdateUI(_currentAbility);
            }
        }
    }

    IEnumerator SetAbilityOnCooldown(Ability ability)
    {
        _cooldownAbilities.Add(ability);
        yield return new WaitForSeconds(ability.cooldownTime);
        _cooldownAbilities.Remove(ability);
    }

    private void UpdateUI(Ability ability)
    {
        ability.skillUIInstance.DisplaySkillTimers();
    }
}
