using UnityEngine;

public class SaveLoadPrototype : MonoBehaviour
{
    //For debugging porpouses

    [SerializeField] Currency currency;

    public void Save()
    {
        SerializationManager.Save(SaveData.Instance);
    }

    public void Load()
    {
        SaveData.Instance = SerializationManager.Load() as SaveData;
        GameEvents.TriggerOnLoad();
    }

    public void UnlockSmashSkill()
    {
        SaveData.Instance.profile.unlockedAbilitiesIDs.Add(1);
    }
}
