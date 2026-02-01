using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    public int countNumber;
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        OnGameStateChanged?.Invoke(CurrentState);
    }

    // Shortcuts
    public void Pause() => ChangeState(GameState.Paused);
    public void Playing() => ChangeState(GameState.Playing);
    public void GameOver() => ChangeState(GameState.GameOver);
    public void MainMenu() => ChangeState(GameState.MainMenu);
}
public enum GameState
{
    None,
    MainMenu,
    Playing,
    Paused,
    GameOver
}
