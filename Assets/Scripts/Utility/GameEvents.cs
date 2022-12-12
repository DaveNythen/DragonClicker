using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void OnLoadEvent();
    public static event OnLoadEvent OnLoad;

    public static void TriggerOnLoad()
    {
        OnLoad?.Invoke();
    }
}
