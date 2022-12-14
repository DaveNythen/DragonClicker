using System.Collections.Generic;

[System.Serializable]
public class PlayerProfile
{
    public string playerName;
    public int currency;
    public List<int> unlockedAbilitiesIDs;
    //boosts
    //(cosmetics)

    public PlayerProfile()
    {
        playerName = "";
        currency = 0;
        unlockedAbilitiesIDs = new List<int>();
    }
}
