using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Transform _pauseMenu;
    [SerializeField] Button _continueButton;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState state)
    {
        if (state == GameState.GameOver)
            GameOver();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.State == GameState.Gameplay)
            ShowPauseMenu();
    }

    public void ShowPauseMenu()
    {
        ShowContinueButton(true);
        _pauseMenu.gameObject.SetActive(true);
        GameManager.Instance.UpdateGameState(GameState.Paused);
    }

    public void GameOver()
    {
        ShowContinueButton(false);
        _pauseMenu.gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        GameManager.Instance.UpdateGameState(GameState.Gameplay);
        _pauseMenu.gameObject.SetActive(false);
    }

    public void RetryButton()
    {
        GameManager.Instance.UpdateGameState(GameState.Gameplay);
        SceneManager.LoadScene(SceneIndex.GAME_ARENA);
    }

    public void ExitButton()
    {
        GameManager.Instance.UpdateGameState(GameState.StartMenu);
        SceneManager.LoadScene(SceneIndex.MENU);
    }

    private void ShowContinueButton(bool isShowed)
    {
        _continueButton.gameObject.SetActive(isShowed);
    }
}
