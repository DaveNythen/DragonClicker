using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Transform _pauseMenu;
    [SerializeField] Button _continueButton;

    private void OnEnable()
    {
        TowerHealth.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        TowerHealth.OnGameOver -= GameOver;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameStatus.IsPaused)
        {
            ShowPauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        ShowContinueButton(true);
        _pauseMenu.gameObject.SetActive(true);
        GameStatus.PauseGame();
    }

    public void GameOver()
    {
        ShowContinueButton(false);
        _pauseMenu.gameObject.SetActive(true);
        GameStatus.PauseGame();
        SerializationManager.Save(SaveData.Instance.profile.currency);
    }

    public void ContinueButton()
    {
        GameStatus.UnPauseGame();
        _pauseMenu.gameObject.SetActive(false);
    }

    public void RetryButton()
    {
        GameStatus.UnPauseGame();
        SceneManager.LoadScene(SceneIndex.GAME_ARENA);
    }

    public void ExitButton()
    {
        GameStatus.UnPauseGame();
        SceneManager.LoadScene(SceneIndex.MENU);
    }

    private void ShowContinueButton(bool isShowed)
    {
        _continueButton.gameObject.SetActive(isShowed);
    }
}
