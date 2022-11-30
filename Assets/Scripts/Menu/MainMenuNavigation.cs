using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneIndex.GAME_ARENA);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
