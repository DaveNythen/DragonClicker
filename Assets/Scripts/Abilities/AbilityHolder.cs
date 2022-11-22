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

    Ability currentAbility;
    private List<Ability> cooldownAbilities;

    private AbilityTrigger abilityTrigger;

    private void Awake()
    {
        abilityTrigger = FindObjectOfType<AbilityTrigger>();
        cooldownAbilities = new List<Ability>();
    }

    void Update()
    {
        foreach (var ability in abilitiesTriggers)
        {
            if (abilityTrigger.TriggerType == ability.triggerType)
            {
                currentAbility = ability.ability;

                if (cooldownAbilities.Contains(currentAbility)) return;

                currentAbility.Activate(abilityTrigger.GetInputInfo());
                abilityTrigger.TriggerType = AbilityTrigger.AbilityTriggerType.none;

                StartCoroutine(SetAbilityOnCooldown(currentAbility, currentAbility.cooldownTime));
            }
        }
    }

    IEnumerator SetAbilityOnCooldown(Ability ability, float cooldownTime)
    {
        cooldownAbilities.Add(ability);
        //Debug.Log($"Cooldown para {ability} durante {cooldownTime}, empezando {Time.time}");
        yield return new WaitForSeconds(cooldownTime);
        cooldownAbilities.Remove(ability);
    }
}
