using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Start()
    {
        UpdateGameState(GameState.StartMenu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartMenu:
                HandleStartMenu();
                break;
            case GameState.Gameplay:
                HandleGameplay();
                break;
            case GameState.Paused:
                HandlePause();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            default:
                Debug.LogError($"{newState} not implemented");
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleStartMenu()
    {
        UnpauseGame();
        SaveData.Instance = SerializationManager.Load() as SaveData;
        GameEvents.TriggerOnLoad();
    }

    private void HandleGameplay()
    {
        UnpauseGame();
    }

    private void HandlePause()
    {
        PauseGame();
    }

    private void HandleGameOver()
    {
        PauseGame();
        SerializationManager.Save(SaveData.Instance.profile.currency);
    }

    private void HandleVictory()
    {
        //TODO -> Go back to Main Menu
        SerializationManager.Save(SaveData.Instance.profile.currency);
    }

    private void PauseGame()
    {
        Time.timeScale = 1f;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 0;
    }
}

public enum GameState
{
    StartMenu,
    Gameplay,
    Paused,
    GameOver,
    Victory
}