using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Gameplay);
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
