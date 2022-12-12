[System.Serializable]
public class SaveData
{
    private static SaveData _instance;
    public static SaveData Instance
    {
        get
        {
            if(_instance == null) _instance = new SaveData();
            return _instance;
        }
        set
        {
            if (value != null) _instance = value;
        }
    }

    public PlayerProfile profile = new PlayerProfile();
}
