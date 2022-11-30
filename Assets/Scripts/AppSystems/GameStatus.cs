using UnityEngine;

public class GameStatus: MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        IsPaused = true;
    }

    public static void UnPauseGame()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
